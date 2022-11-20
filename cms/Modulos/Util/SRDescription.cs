
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

/*Class to creat a claculator application it is a sim[le calculator you can use
*the logic to make a scientific calculator source is open for you.*/
public class Calc : Form
{
    /*Enum for holding Operator*/
    protected enum Operator
    {
        NO_OP,
        ADD,
        SUB,
        MUL,
        DIV
    }
    /*Memory Store element*/
    private double m_MStore = 0;
    /*To hold the the result*/
    private double m_Result = 0;
    /*To hold the operator*/
    private Operator m_OP = Operator.NO_OP;
    /*To recognise is it start of calculation*/
    private bool m_Start = true;
    /*To make dession to append test or not*/
    private bool m_Append = false;
    /*To make dission can do the backspace*/
    private bool m_Backspace = true;
    /*To make dission can write*/
    private bool m_CanWrite = true;
    /*UI Componant.*/
    private System.ComponentModel.Container components;
    private MenuItem menuItem5;
    private MenuItem menuItem4;
    private MenuItem menuItem3;
    private Button m_Dot;
    private Button m_BS;
    private Button m_Res;
    private Button m_C;
    private Button m_Div;
    private Button m_Mul;
    private Button m_Sub;
    private Button m_Add;
    private Button m_MS;
    private Button m_Zero;
    private Button m_MR;
    private Button m_Nine;
    private Button m_Eight;
    private Button m_Seven;
    private Button m_Six;
    private Button m_Five;
    private Button m_Four;
    private Button m_Three;
    private Button m_Two;
    private Button m_One;
    private TextBox m_TB;
    private MenuItem menuItem2;
    private MenuItem menuItem1;
    private MainMenu mainMenu1;
    /*Want by WinForm class*/
    public Calc()
    {
        InitializeComponent();
    }
    /*Want by winform class*/
    //public override void Dispose()
    //{
    //    base.Dispose();
    //    components.Dispose();
    //}
    /*Inintialise tha all the componant.*/
    private void InitializeComponent()
    {
        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Calc));
        this.components = new System.ComponentModel.Container();
        this.m_Mul = new Button();
        this.m_Five = new Button();
        this.m_C = new Button();
        this.menuItem3 = new MenuItem();
        this.m_One = new Button();
        this.menuItem1 = new MenuItem();
        this.menuItem2 = new MenuItem();
        this.m_Nine = new Button();
        this.m_Three = new Button();
        this.m_MR = new Button();
        this.m_Add = new Button();
        this.m_Two = new Button();
        this.m_MS = new Button();
        this.m_Zero = new Button();
        this.m_Eight = new Button();
        this.m_TB = new TextBox();
        this.m_Dot = new Button();
        this.m_Six = new Button();
        this.m_Seven = new Button();
        this.m_Four = new Button();
        this.m_Div = new Button();
        this.menuItem4 = new MenuItem();
        this.menuItem5 = new MenuItem();
        this.m_Sub = new Button();
        this.mainMenu1 = new MainMenu();
        this.m_BS = new Button();
        this.m_Res = new Button();
        m_Mul.Location = new System.Drawing.Point(184, 192);
        m_Mul.ForeColor = System.Drawing.Color.Black;
        m_Mul.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Mul.Size = new System.Drawing.Size(88, 32);
        m_Mul.TabIndex = 15;
        m_Mul.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Mul.Text = "*";
        m_Mul.Click += new System.EventHandler(this.m_Mul_Click);
        m_Five.Location = new System.Drawing.Point(64, 144);
        m_Five.ForeColor = System.Drawing.Color.Red;
        m_Five.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Five.Size = new System.Drawing.Size(40, 32);
        m_Five.TabIndex = 5;
        m_Five.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Five.Text = "5";
        m_Five.Click += new System.EventHandler(this.m_Value_Click);
        m_C.Location = new System.Drawing.Point(64, 48);
        m_C.ForeColor = System.Drawing.Color.Black;
        m_C.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_C.Size = new System.Drawing.Size(40, 32);
        m_C.TabIndex = 17;
        m_C.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_C.Text = "C";
        m_C.Click += new System.EventHandler(this.m_C_Click);
        menuItem3.Text = "Help";
        menuItem3.Index = 1;
        menuItem3.MenuItems.AddRange(new MenuItem[2] { this.menuItem4, this.menuItem5 });
        m_One.Location = new System.Drawing.Point(8, 96);
        m_One.ForeColor = System.Drawing.Color.Red;
        m_One.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_One.Size = new System.Drawing.Size(40, 32);
        m_One.TabIndex = 1;
        m_One.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_One.Text = "1";
        m_One.Click += new System.EventHandler(this.m_Value_Click);
        menuItem1.Text = "Menu";
        menuItem1.Index = 0;
        menuItem1.MenuItems.AddRange(new MenuItem[1] { this.menuItem2 });
        menuItem2.Text = "Exit";
        menuItem2.Index = 0;
        menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
        m_Nine.Location = new System.Drawing.Point(120, 192);
        m_Nine.ForeColor = System.Drawing.Color.Red;
        m_Nine.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Nine.Size = new System.Drawing.Size(40, 32);
        m_Nine.TabIndex = 9;
        m_Nine.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Nine.Text = "9";
        m_Nine.Click += new System.EventHandler(this.m_Value_Click);
        m_Three.Location = new System.Drawing.Point(120, 96);
        m_Three.ForeColor = System.Drawing.Color.Red;
        m_Three.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Three.Size = new System.Drawing.Size(40, 32);
        m_Three.TabIndex = 3;
        m_Three.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Three.Text = "3";
        m_Three.Click += new System.EventHandler(this.m_Value_Click);
        m_MR.Location = new System.Drawing.Point(8, 240);
        m_MR.ForeColor = System.Drawing.SystemColors.ActiveCaption;
        m_MR.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_MR.Size = new System.Drawing.Size(40, 32);
        m_MR.TabIndex = 10;
        m_MR.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_MR.Text = "MR";
        m_MR.Click += new System.EventHandler(this.m_MR_Click);
        m_Add.Location = new System.Drawing.Point(184, 96);
        m_Add.ForeColor = System.Drawing.SystemColors.WindowText;
        m_Add.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Add.Size = new System.Drawing.Size(88, 32);
        m_Add.TabIndex = 13;
        m_Add.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Add.Text = "+";
        m_Add.Click += new System.EventHandler(this.m_Add_Click);
        m_Two.Location = new System.Drawing.Point(64, 96);
        m_Two.ForeColor = System.Drawing.Color.Red;
        m_Two.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Two.Size = new System.Drawing.Size(40, 32);
        m_Two.TabIndex = 2;
        m_Two.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Two.Text = "2";
        m_Two.Click += new System.EventHandler(this.m_Value_Click);
        m_MS.Location = new System.Drawing.Point(120, 240);
        m_MS.ForeColor = System.Drawing.SystemColors.ActiveCaption;
        m_MS.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_MS.Size = new System.Drawing.Size(40, 32);
        m_MS.TabIndex = 12;
        m_MS.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_MS.Text = "MS";
        m_MS.Click += new System.EventHandler(this.m_MS_Click);
        m_Zero.Location = new System.Drawing.Point(64, 240);
        m_Zero.ForeColor = System.Drawing.Color.Red;
        m_Zero.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Zero.Size = new System.Drawing.Size(40, 32);
        m_Zero.TabIndex = 11;
        m_Zero.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Zero.Text = "0";
        m_Zero.Click += new System.EventHandler(this.m_Value_Click);
        m_Eight.Location = new System.Drawing.Point(64, 192);
        m_Eight.ForeColor = System.Drawing.Color.Red;
        m_Eight.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Eight.Size = new System.Drawing.Size(40, 32);
        m_Eight.TabIndex = 8;
        m_Eight.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Eight.Text = "8";
        m_Eight.Click += new System.EventHandler(this.m_Value_Click);
        m_TB.Location = new System.Drawing.Point(8, 8);
        m_TB.ReadOnly = true;
        m_TB.Text = "0";
        m_TB.MaxLength = 12;
        m_TB.Font = new System.Drawing.Font("Tahoma", 12, System.Drawing.FontStyle.Bold);
        m_TB.TabIndex = 0;
        m_TB.Size = new System.Drawing.Size(264, 27);
        m_TB.BackColor = System.Drawing.SystemColors.ScrollBar;
        m_TB.TextAlign = HorizontalAlignment.Right;
        m_Dot.Location = new System.Drawing.Point(120, 48);
        m_Dot.ForeColor = System.Drawing.Color.Black;
        m_Dot.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Dot.Size = new System.Drawing.Size(40, 32);
        m_Dot.TabIndex = 20;
        m_Dot.Font = new System.Drawing.Font("Tahoma", 16, System.Drawing.FontStyle.Bold);
        m_Dot.Text = ".";
        m_Dot.Click += new System.EventHandler(this.m_Value_Click);
        m_Six.Location = new System.Drawing.Point(120, 144);
        m_Six.ForeColor = System.Drawing.Color.Red;
        m_Six.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Six.Size = new System.Drawing.Size(40, 32);
        m_Six.TabIndex = 6;
        m_Six.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Six.Text = "6";
        m_Six.Click += new System.EventHandler(this.m_Value_Click);
        m_Seven.Location = new System.Drawing.Point(8, 192);
        m_Seven.ForeColor = System.Drawing.Color.Red;
        m_Seven.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Seven.Size = new System.Drawing.Size(40, 32);
        m_Seven.TabIndex = 7;
        m_Seven.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Seven.Text = "7";
        m_Seven.Click += new System.EventHandler(this.m_Value_Click);
        m_Four.Location = new System.Drawing.Point(8, 144);
        m_Four.ForeColor = System.Drawing.Color.Red;
        m_Four.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Four.Size = new System.Drawing.Size(40, 32);
        m_Four.TabIndex = 4;
        m_Four.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Four.Text = "4";
        m_Four.Click += new System.EventHandler(this.m_Value_Click);
        m_Div.Location = new System.Drawing.Point(184, 240);
        m_Div.ForeColor = System.Drawing.Color.Black;
        m_Div.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Div.Size = new System.Drawing.Size(88, 32);
        m_Div.TabIndex = 16;
        m_Div.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Div.Text = "/";
        m_Div.Click += new System.EventHandler(this.m_Div_Click);
        menuItem4.Text = "Help";
        menuItem4.Index = 0;
        menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
        menuItem5.Text = "About Calc.";
        menuItem5.Index = 1;
        menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
        m_Sub.Location = new System.Drawing.Point(184, 144);
        m_Sub.ForeColor = System.Drawing.SystemColors.WindowText;
        m_Sub.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Sub.Size = new System.Drawing.Size(88, 32);
        m_Sub.TabIndex = 14;
        m_Sub.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Sub.Text = "-";
        m_Sub.Click += new System.EventHandler(this.m_Sub_Click);
        mainMenu1.MenuItems.AddRange(new MenuItem[2] { this.menuItem1, this.menuItem3 });
        m_BS.Location = new System.Drawing.Point(8, 48);
        m_BS.ForeColor = System.Drawing.Color.Black;
        m_BS.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_BS.Size = new System.Drawing.Size(40, 32);
        m_BS.TabIndex = 19;
        m_BS.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_BS.Text = "BS";
        m_BS.Click += new System.EventHandler(this.m_BS_Click);
        m_Res.Location = new System.Drawing.Point(184, 48);
        m_Res.ForeColor = System.Drawing.Color.Black;
        m_Res.BackColor = (System.Drawing.Color)System.Drawing.Color.FromArgb(192, 192, 0);
        m_Res.Size = new System.Drawing.Size(88, 32);
        m_Res.TabIndex = 18;
        m_Res.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Bold);
        m_Res.Text = "=";
        m_Res.Click += new System.EventHandler(this.m_Res_Click);
        this.Text = "Abhijeet's Calc";
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.FormBorderStyle = FormBorderStyle.Fixed3D;
        this.ForeColor = System.Drawing.Color.Red;
        this.TransparencyKey = (System.Drawing.Color)System.Drawing.Color.FromArgb(255, 128, 0);
        this.TopMost = true;
        this.Menu = this.mainMenu1;
        this.BackColor = System.Drawing.SystemColors.Desktop;
        this.ClientSize = new System.Drawing.Size(278, 279);
        this.Controls.Add(this.m_Dot);
        this.Controls.Add(this.m_BS);
        this.Controls.Add(this.m_Res);
        this.Controls.Add(this.m_C);
        this.Controls.Add(this.m_Div);
        this.Controls.Add(this.m_Mul);
        this.Controls.Add(this.m_Sub);
        this.Controls.Add(this.m_Add);
        this.Controls.Add(this.m_MS);
        this.Controls.Add(this.m_Zero);
        this.Controls.Add(this.m_MR);
        this.Controls.Add(this.m_Nine);
        this.Controls.Add(this.m_Eight);
        this.Controls.Add(this.m_Seven);
        this.Controls.Add(this.m_Six);
        this.Controls.Add(this.m_Five);
        this.Controls.Add(this.m_Four);
        this.Controls.Add(this.m_Three);
        this.Controls.Add(this.m_Two);
        this.Controls.Add(this.m_One);
        this.Controls.Add(this.m_TB);
    }
    /*Event Handlers*/
    protected void menuItem4_Click(object sender, System.EventArgs e)
    {
        MessageBox.Show("So Simple application still you want Help? if yes contact me at toabhijeet@yahoo.com");
    }
    protected void menuItem5_Click(object sender, System.EventArgs e)
    {
        MessageBox.Show("This Calc Is Developed By Abhijeet :-> toabhijeet@yahoo.com");
    }
    protected void m_MS_Click(object sender, System.EventArgs e)
    {
        this.m_MStore = Convert.ToDouble(this.m_TB.Text.Trim());
    }
    protected void m_MR_Click(object sender, System.EventArgs e)
    {
        if (this.m_CanWrite)
        {
            this.m_TB.Text = this.m_MStore.ToString();
        }
    }
    protected void m_BS_Click(object sender, System.EventArgs e)
    {
        if (this.m_Backspace)
        {
            String sSub = this.m_TB.Text.Trim();
            if (sSub.Length > 1)
            {
                this.m_TB.Text = sSub.Substring(0, sSub.Length - 1);
            }
            else
            {
                this.m_TB.Text = "0";
                this.m_Append = false;
            }
        }
    }
    protected void m_C_Click(object sender, System.EventArgs e)
    {
        this.m_TB.Text = "0";
        this.m_Result = 0;
        this.m_Start = true;
        this.m_Append = false;
        this.m_CanWrite = true;
        this.m_Backspace = true;
        this.m_OP = Operator.NO_OP;
    }
    protected void m_Sub_Click(object sender, System.EventArgs e)
    {
        this.m_Append = false;
        if (!this.m_Start)
        {
            CalculateResult();
            if (this.m_OP != Operator.SUB)
            {
                this.m_OP = Operator.SUB;
            }
        }
        else
        {
            this.m_OP = Operator.SUB;
            this.m_Result = Convert.ToDouble(this.m_TB.Text);
            this.m_Start = false;
        }
        this.m_CanWrite = true;
    }
    protected void m_Mul_Click(object sender, System.EventArgs e)
    {
        this.m_Append = false;
        if (!this.m_Start)
        {
            CalculateResult();
            if (this.m_OP != Operator.MUL)
            {
                this.m_OP = Operator.MUL;
            }
        }
        else
        {
            this.m_OP = Operator.MUL;
            this.m_Result = Convert.ToDouble(this.m_TB.Text);
            this.m_Start = false;
        }
        this.m_CanWrite = true;
    }
    protected void m_Div_Click(object sender, System.EventArgs e)
    {
        this.m_Append = false;
        if (!this.m_Start)
        {
            CalculateResult();
            if (this.m_OP != Operator.DIV)
            {
                this.m_OP = Operator.DIV;
            }
        }
        else
        {
            this.m_OP = Operator.DIV;
            this.m_Result = Convert.ToDouble(this.m_TB.Text);
            this.m_Start = false;
        }
        this.m_CanWrite = true;
    }
    protected void m_Res_Click(object sender, System.EventArgs e)
    {
        this.CalculateResult();
        this.m_Start = true;
    }
    protected void m_Add_Click(object sender, System.EventArgs e)
    {
        this.m_Append = false;
        if (!this.m_Start)
        {
            CalculateResult();
            if (this.m_OP != Operator.ADD)
            {
                this.m_OP = Operator.ADD;
            }
        }
        else
        {
            this.m_OP = Operator.ADD;
            this.m_Result = Convert.ToDouble(this.m_TB.Text.Trim());
            this.m_Start = false;
        }
        this.m_CanWrite = true;
    }
    protected void m_Value_Click(object sender, System.EventArgs e)
    {
        if (this.m_CanWrite)
        {
            /*Formate ToString returns is like "Button, text: <value>" so 
            *retriving value from it.*/
            int iIndex = sender.ToString().IndexOf(":");
            String sSub = sender.ToString().Substring(iIndex + 1).Trim();
            if (!(sSub.Equals("0") && sSub.Equals(this.m_TB.Text.Trim())))
            {
                ShowText(sSub);
            }
            else
            {
                this.m_Append = false;
            }
            this.m_Backspace = true;
        }
    }
    protected void menuItem2_Click(object sender, System.EventArgs e)
    {
        Application.Exit();
    }
    /*Calculate the result*/
    private void CalculateResult()
    {
        switch (this.m_OP)
        {
            case Operator.ADD:
                this.m_Result += Convert.ToDouble(this.m_TB.Text.Trim());
                break;
            case Operator.SUB:
                this.m_Result -= Convert.ToDouble(this.m_TB.Text.Trim());
                break;
            case Operator.MUL:
                this.m_Result *= Convert.ToDouble(this.m_TB.Text.Trim());
                break;
            case Operator.DIV:
                this.m_Result /= Convert.ToDouble(this.m_TB.Text.Trim());
                break;
            default:
                break;
        }
        ShowResult();
    }
    /*Shows the result.*/
    private void ShowResult()
    {
        this.m_Backspace = false;
        this.m_TB.Text = this.m_Result.ToString();
        this.m_CanWrite = false;
    }
    /*Shows the values entered by user*/
    private void ShowText(String sSub)
    {
        if (this.m_CanWrite)
        {
            if (this.m_Append)
            {
                this.m_TB.AppendText(sSub.Trim());
            }
            else
            {
                this.m_TB.Text = sSub;
                this.m_Append = true;
            }
        }
    }

}
