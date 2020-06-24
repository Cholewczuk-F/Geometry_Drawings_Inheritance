using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometria
{
    public partial class Geometria : Form
    {
        BindingList<GeoObject> objectEntries = new BindingList<GeoObject>();
        Pen thePen = new Pen(Color.Black);
        Brush theBrush = (Brush)Brushes.Black;
        Graphics graphics = null;
        Font tahoma6 = new Font("Tahoma", 6);

        uint canvasWidth;
        uint canvasHeight;
        public Geometria()
        {
            InitializeComponent();
        }

        private void Geometria_Load(object sender, EventArgs e)
        {
            setup_form();
            canvas.Refresh();
        }

        private void setup_form()
        {
            typeCombo.SelectedIndex = 0;
            this.entryView.AutoGenerateColumns = false;
            this.entryView.EditMode = DataGridViewEditMode.EditProgrammatically;

            List<string> property = new List<string> { "id", "type", "properties" };
            List<string> header = new List<string> { "ID", "Type", "Properties" };

            for(int i = 0; i < header.Count(); ++i)
            {
                DataGridViewColumn col;
                if(i < 2)
                {
                    col = new DataGridViewTextBoxColumn();
                    if(header[i] == "ID")
                    {
                        col.Width = 40;
                        
                    }else
                    {
                        col.Width = 70;
                    }
                }else
                {
                    col = new DataGridViewButtonColumn()
                    {
                        Text = header[i],
                        Width = 90,
                        UseColumnTextForButtonValue = true
                    };
                }

                col.HeaderText = header[i];
                col.DataPropertyName = property[i];
                col.Name = property[i];
                this.entryView.Columns.Add(col);
            }
            this.entryView.DataSource = objectEntries;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            switch(typeCombo.SelectedIndex)
            {
                case 0:
                    {
                        uint xVal, yVal;
                        if(uint.TryParse(xBox.Text, out xVal) && uint.TryParse(yBox.Text, out yVal))
                        {
                            Punkt tmp = new Punkt(xVal, yVal);
                            objectEntries.Add(tmp);
                        }
                        break;
                    }
                case 1:
                    {
                        uint xVal, yVal, radius;
                        if (uint.TryParse(xBox.Text, out xVal) && uint.TryParse(yBox.Text, out yVal) && uint.TryParse(radiusBox.Text, out radius))
                        {
                            Okrag tmp = new Okrag(new Punkt(xVal, yVal), radius);
                            objectEntries.Add(tmp);
                        }
                        break;
                    }
                case 2:
                    {
                        List<Punkt> triangleData = trianglePrompt.ShowDialog("Input coordinates for triangle: ", "Triangle creation.", canvasWidth, canvasHeight);
                        if(triangleData != null)
                        {
                            Trojkat tmp = new Trojkat(triangleData[0], triangleData[1], triangleData[2]);
                            objectEntries.Add(tmp);
                        }
                        break;
                    }
                case 3:
                    {
                        List<Punkt> polygonData = polygonPrompt.ShowDialog("Input coordinates for polygon: ", "Polygon creation.", canvasWidth, canvasHeight);
                        if (polygonData != null)
                        {
                            Wielobok tmp = new Wielobok(polygonData);
                            MessageBox.Show(tmp.Info());
                            objectEntries.Add(tmp);
                        }
                        break;
                    }
            }

            canvas.Refresh();
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            graphics = canvas.CreateGraphics();
            setup_canvas();
            thePen.Width = 1;

            foreach(object entry in objectEntries)
            {
                if(entry is Punkt)
                {
                    drawPoint((Punkt)entry);
                }else if(entry is Okrag)
                {
                    drawCircle((Okrag)entry);
                }else if(entry is Trojkat)
                {
                    drawTriangle((Trojkat)entry);
                }else if(entry is Wielobok)
                {
                    drawPolygon((Wielobok)entry);
                }
            }
        }

        private void setup_canvas()
        {
            canvasHeight = (uint)canvas.Height;
            canvasWidth = (uint)canvas.Width;

            Point start = new Point(0, 0);
            Point horEnd = new Point(canvas.Width, 0);
            Point verEnd = new Point(0, canvas.Height);

            thePen.Width = 1;
            graphics.DrawLine(thePen, 0, 0, canvas.Width, 0);
            graphics.DrawLine(thePen, 0, 0, 0, canvas.Height);
            graphics.DrawLine(thePen, 0, 0, 10, 10);

            for(int i = 0; i < canvas.Width; i+= 100)
            {
                graphics.DrawString(i.ToString(), tahoma6, theBrush, i - 17, 2);
                graphics.DrawLine(thePen, i, 0, i, 10);
            }

            for (int i = 0; i < canvas.Height; i += 100)
            {
                graphics.DrawString(i.ToString(), tahoma6, theBrush, 2, i - 12);
                graphics.DrawLine(thePen, 0, i, 10, i);
            }

            thePen.Width = 1;

        }

        void drawPoint(Punkt toBeDrawn)
        {
            graphics.FillRectangle(theBrush, toBeDrawn.X, toBeDrawn.Y, 1, 1);
        }

        void drawCircle(Okrag toBeDrawn)
        {
            int xDistance = (int)(toBeDrawn.Centre.X - toBeDrawn.Radius);
            int yDistance = (int)(toBeDrawn.Centre.Y - toBeDrawn.Radius);
            int rectSize = (int)(toBeDrawn.Radius * 2);
            graphics.DrawEllipse(thePen, xDistance, yDistance, rectSize, rectSize);
        }

        void drawTriangle(Trojkat toBeDrawn)
        {
            Point A = new Point((int)toBeDrawn.corA.X, (int)toBeDrawn.corA.Y);
            Point B = new Point((int)toBeDrawn.corB.X, (int)toBeDrawn.corB.Y);
            Point C = new Point((int)toBeDrawn.corC.X, (int)toBeDrawn.corC.Y);
            graphics.DrawLine(thePen, A, B);
            graphics.DrawLine(thePen, B, C);
            graphics.DrawLine(thePen, C, A);
        }

        void drawPolygon(Wielobok toBeDrawn)
        {
            uint pointsAmount = (uint)toBeDrawn.points.Count();
            Point[] pointArray = new Point[pointsAmount];
            
            for(int i = 0; i < pointsAmount; ++i)
            {
                pointArray[i].X = (int)toBeDrawn.points[i].X;
                pointArray[i].Y = (int)toBeDrawn.points[i].Y;
            }
            graphics.DrawPolygon(thePen, pointArray);
        }

        private void entryView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                try
                {
                    if (e.ColumnIndex == 2)//properties
                    {
                        MessageBox.Show(objectEntries[e.RowIndex].Info());
                    }
                }
                catch (NullReferenceException)
                {
                }

            }
        }

        private void yBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(yBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter appropriate coordinate Y.");
                yBox.Text = yBox.Text.Remove(yBox.Text.Length - 1);
            }
        }

        private void xBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(xBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter appropriate coordinate X.");
                xBox.Text = xBox.Text.Remove(xBox.Text.Length - 1);
            }
        }

        private void typeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (typeCombo.SelectedIndex)
            {
                case 0:
                    {
                        xBox.Enabled = true;
                        yBox.Enabled = true;
                        radiusBox.Enabled = false;
                        addButton.Text = "Add";
                        break;
                    }
                case 1:
                    {
                        xBox.Enabled = true;
                        yBox.Enabled = true;
                        radiusBox.Enabled = true;
                        addButton.Text = "Add";
                        break;
                    }
                case 2:
                    {
                        xBox.Enabled = false;
                        yBox.Enabled = false;
                        radiusBox.Enabled = false;
                        addButton.Text = "Set up";
                        break;
                    }
                case 3:
                    {
                        xBox.Enabled = false;
                        yBox.Enabled = false;
                        radiusBox.Enabled = false;
                        addButton.Text = "Set up";
                        break;
                    }
            }
        }
    }


    public abstract class GeoObject
    {
        public uint Id { get; set; }
        public string Type { get; set; }
        public static uint objectsAmount = 0;

        public abstract string Info();
    }

    public class Punkt : GeoObject
    {
        private uint x;
        public uint X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }


        private uint y;
        public uint Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public Punkt(uint x, uint y)
        {
            this.Id = objectsAmount;
            this.Type = "Punkt";
            this.x = x;
            this.y = y;
            GeoObject.objectsAmount++;
        }

        public override string Info()
        {
            return (string)$"ID: {Id}\nType: {Type}\nValue x: {x}\nValue y: {y}\n";
        }
    }

    public class Okrag : GeoObject
    {
        private Punkt centre;
        public Punkt Centre
        {
            get
            {
                return centre;
            }
            set
            {
                centre = value;
            }
        }

        private uint radius;
        public uint Radius
        {
            get
            {
                return radius;
            }
            set
            {
                this.radius = value;
            }
        }

        public Okrag(Punkt centre, uint radius)
        {
            this.Id = objectsAmount;
            this.Type = "Okrag";
            this.Centre = centre;
            this.Radius = radius;
            GeoObject.objectsAmount++;
        }

        public override string Info()
        {
            return (string)$"ID: {Id}\nType: {Type}\nCenter x: {Centre.X}\nCenter y: {Centre.Y}\nRadius: {Radius}\n";
        }
    }

    public class Trojkat : GeoObject
    {
        public Punkt corA { get; set; }
        public Punkt corB { get; set; }
        public Punkt corC { get; set; } 

        public Trojkat(Punkt corA, Punkt corB, Punkt corC)
        {
            this.Id = objectsAmount;
            this.Type = "Trojkat";
            this.corA = corA;
            this.corB = corB;
            this.corC = corC;
            GeoObject.objectsAmount++;
        }

        public override string Info()
        {
            return (string)$"ID: {Id}\nType: {Type}\nCoordinate A x: {corA.X}\nCoordinate A y: {corA.Y}\nCoordinate B x: {corB.X}\nCoordinate B y: {corB.Y}\nCoordinate C x: {corC.X}\nCoordinate C y: {corC.Y}";
        }
    }

    public class Wielobok : GeoObject
    {
        public List<Punkt> points { get; set; }

        public Wielobok(List<Punkt> points)
        {
            this.Id = objectsAmount;
            this.Type = "Wielobok";
            this.points = points;
            GeoObject.objectsAmount++;
        }

        public override string Info()
        {
            string infoStr = $"ID: {Id}\nType: {Type}";
            char coordinateChar = 'A';

            for(int i = 0; i < points.Count(); ++i)
            {
                infoStr += "\nCoordinate " + coordinateChar + i + " x: " + points[i].X + "\nCoordinate " + coordinateChar + i + " y: " + points[i].Y;
            }
            return infoStr;
        }
    }

    public static class trianglePrompt
    {
        public static List<Punkt> ShowDialog(string text, string caption, uint canvasWidth, uint canvasHeight)
        {
            List<Punkt> data = new List<Punkt>();
            Form prompt = new Form()
            {
                Width = 260,
                Height = 210,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Width = 200, Text = text };

            Label labelA_X = new Label() { Left = 20, Top = 50, Width = 25, Text = "A x:" };
            TextBox valA_X = new TextBox() { Left = 50, Top = 45, Width = 40 };
            Label labelA_Y = new Label() { Left = 130, Top = 50, Width = 25, Text = "A y:" };
            TextBox valA_Y = new TextBox() { Left = 160, Top = 45, Width = 40 };

            Label labelB_X = new Label() { Left = 20, Top = 80, Width = 25, Text = "B x:" };
            TextBox valB_X = new TextBox() { Left = 50, Top = 75, Width = 40 };
            Label labelB_Y = new Label() { Left = 130, Top = 80, Width = 25, Text = "B y:" };
            TextBox valB_Y = new TextBox() { Left = 160, Top = 75, Width = 40 };

            Label labelC_X = new Label() { Left = 20, Top = 110, Width = 25, Text = "C x:" };
            TextBox valC_X = new TextBox() { Left = 50, Top = 105, Width = 40 };
            Label labelC_Y = new Label() { Left = 130, Top = 110, Width = 25, Text = "C y:" };
            TextBox valC_Y = new TextBox() { Left = 160, Top = 105, Width = 40 };

            Button confirmation = new Button() { Text = "Confirm", Left = 130, Top = 140, Width = 70, DialogResult = DialogResult.None };
            Button cancelOperation = new Button() { Text = "Cancel", Left = 40, Top = 140, Width = 70, DialogResult = DialogResult.Cancel };
            //confirmation.Click += (sender, e) => { prompt.Close(); };
            confirmation.Click += (sender, e) => 
            {
                uint aX, aY, bX, bY, cX, cY;

                if(!uint.TryParse(valA_X.Text, out aX))
                {
                    MessageBox.Show("Coordinate X of A inappropriate.");
                }else if(!uint.TryParse(valA_Y.Text, out aY))
                {
                    MessageBox.Show("Coordinate Y of A inappropriate.");
                }
                else if (!uint.TryParse(valB_X.Text, out bX))
                {
                    MessageBox.Show("Coordinate X of B inappropriate.");
                }
                else if (!uint.TryParse(valB_Y.Text, out bY))
                {
                    MessageBox.Show("Coordinate Y of B inappropriate.");
                }
                else if (!uint.TryParse(valC_X.Text, out cX))
                {
                    MessageBox.Show("Coordinate X of C inappropriate.");
                }
                else if (!uint.TryParse(valC_Y.Text, out cY))
                {
                    MessageBox.Show("Coordinate Y of C inappropriate.");
                }
                else if ((aX > canvasWidth) || (bX > canvasWidth) || (cX > canvasWidth))
                {
                    MessageBox.Show("Coordinate X out of range. Width: " + canvasWidth);
                }else if((aY > canvasHeight) || (bY > canvasHeight) || (cY > canvasHeight))
                {
                    MessageBox.Show("Coordinate Y out of range. Height: " + canvasHeight);
                }
                else
                {
                    data.Add(new Punkt(aX, bX));
                    data.Add(new Punkt(bX, bY));
                    data.Add(new Punkt(cX, cY));

                    prompt.DialogResult = DialogResult.OK;
                    //prompt.Close();
                }
            
            };

            prompt.Controls.Add(labelA_X);
            prompt.Controls.Add(valA_X);
            prompt.Controls.Add(labelA_Y);
            prompt.Controls.Add(valA_Y);

            prompt.Controls.Add(labelB_X);
            prompt.Controls.Add(valB_X);
            prompt.Controls.Add(labelB_Y);
            prompt.Controls.Add(valB_Y);

            prompt.Controls.Add(labelC_X);
            prompt.Controls.Add(valC_X);
            prompt.Controls.Add(labelC_Y);
            prompt.Controls.Add(valC_Y);

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancelOperation);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancelOperation;

            return prompt.ShowDialog() == DialogResult.OK ? data : null;
        }
    }


    public static class polygonPrompt
    {
        public static List<Punkt> ShowDialog(string text, string caption, uint canvasWidth, uint canvasHeight)
        {
            List<Punkt> data = new List<Punkt>();
            Form prompt = new Form()
            {
                Width = 260,
                Height = 210,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };


            Label textLabel = new Label() { Left = 20, Top = 20, Width = 200, Text = text };
            Label statusLabel = new Label() { Left = 20, Top = 50, Width = 200, Text = "Points registered: " + data.Count() + ". Minimum: 4" };

            Label label_X = new Label() { Left = 20, Top = 80, Width = 25, Text = "A x:" };
            TextBox val_X = new TextBox() { Left = 50, Top = 75, Width = 40 };
            Label label_Y = new Label() { Left = 130, Top = 80, Width = 25, Text = "A y:" };
            TextBox val_Y = new TextBox() { Left = 160, Top = 75, Width = 40 };


            Button cancelOperation = new Button() { Text = "Cancel", Left = 20, Top = 140, Width = 60, DialogResult = DialogResult.Cancel };
            Button confirmation = new Button() { Text = "Confirm", Left = 180, Top = 140, Width = 60, DialogResult = DialogResult.None };
            Button addPoint = new Button() { Text = "Add Point", Left = 100, Top = 140, Width = 60, DialogResult = DialogResult.None };
            
            confirmation.Click += (sender, e) =>
            {
                if (data.Count() < 4)
                {
                    MessageBox.Show("Not enough point for polygon construction.\nConsider adding more.");
                }
                else
                {
                    prompt.DialogResult = DialogResult.OK;
                }
            };

            addPoint.Click += (sender, e) =>
            {
                uint xVal, yVal;

                if (!uint.TryParse(val_X.Text, out xVal))
                {
                    MessageBox.Show("Coordinate X of inappropriate.");
                }
                else if (!uint.TryParse(val_Y.Text, out yVal))
                {
                    MessageBox.Show("Coordinate Y of inappropriate.");
                }
                else if (xVal > canvasWidth)
                {
                    MessageBox.Show("Coordinate X out of range. Width: " + canvasWidth);
                }
                else if (yVal > canvasHeight)
                {
                    MessageBox.Show("Coordinate Y out of range. Height: " + canvasHeight);
                }
                else
                {
                    bool entryExists = false;
                    foreach(Punkt entry in data)
                    {
                        if(entry.X == xVal && entry.Y == yVal)
                        {
                            MessageBox.Show("Such point already exists! Enter different coordinates.");
                            entryExists = true;
                            break;
                        }
                    }
                    if (!entryExists)
                    {
                        data.Add(new Punkt(xVal, yVal));
                        statusLabel.Text = "Points registered: " + data.Count() + ". Minimum: 4";
                    }
                }
            };

            prompt.Controls.Add(label_X);
            prompt.Controls.Add(val_X);
            prompt.Controls.Add(label_Y);
            prompt.Controls.Add(val_Y);

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(statusLabel);

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancelOperation);
            prompt.Controls.Add(addPoint);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancelOperation;

            return prompt.ShowDialog() == DialogResult.OK ? data : null;
        }
    }
}
