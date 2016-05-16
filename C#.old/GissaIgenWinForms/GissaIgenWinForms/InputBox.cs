using System;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

public class InputBox : Form
{
    // skapa komponenterna
    Label lab = new Label();
    TextBox box = new TextBox();
    Button ok = new Button();
    Button can = new Button();
    ErrorProvider err = new ErrorProvider();

    private InputBox(string txt, string header, string init)
    {
        Controls.Add(lab); Controls.Add(box);
        Controls.Add(ok); Controls.Add(can);
        // egenskaper för dialogrutan
        Size = DialogSize;
        Font = DialogFont;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = MinimizeBox = false;
        Text = header;
        VisibleChanged += Dialog_VisibleChanged; // koppla hanterare
        AcceptButton = ok; // gör att Enter-tangent kan kan användas
        // egenskaper för textboxen
        box.Size = new Size(ClientSize.Width - 40,
                            box.PreferredSize.Height);
        box.Location = new Point((ClientSize.Width - box.Width) / 2,
                                 (ClientSize.Height - box.Height) / 2);
        box.Text = init;
        // egenskaper för Label-komponenten
        lab.AutoSize = true;
        lab.Text = txt;
        lab.Location = new Point(box.Left,
                                 ClientSize.Height / 4 - lab.Height / 2);
        // egenskaper för Avsluta-knappen
        can.AutoSize = true;
        can.Text = str[2];
        can.Location = new Point(ClientSize.Width / 2 + 10,
                      (ClientSize.Height + box.Bottom - can.Height) / 2);
        can.DialogResult = DialogResult.Cancel;
        // egenskaper för OK-knappen
        ok.Size = can.Size;
        ok.Text = str[1];
        ok.Location = new Point(can.Left - 20 - ok.Width, can.Top);
        ok.Click += ok_Click;     // koppla hanterare
    }

    private void Dialog_VisibleChanged(object sender, EventArgs e)
    {
        if (Visible)
        {
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            SetDesktopLocation((r.Width - Width) / 2, (r.Height - Height) / 2);
        }
    }

    private void ok_Click(object sender, EventArgs e)
    {
        if (box.Text.Trim().Length > 0)
            DialogResult = DialogResult.OK;
        else
        {
            err.SetError(box, str[3]);
            DialogResult = DialogResult.None;
        }
    }

    // statiska egenskaper och metoder
    public static Size DialogSize = new Size(250, 130);
    public static Font DialogFont = DefaultFont;
    private static string[] str;

    static InputBox()
    {   // statisk konstruktor
        if (CultureInfo.CurrentCulture.Name.StartsWith("sv"))
            str = new string[] { "Indata", "OK", "Avbryt", "Måste fyllas i" };
        else
            str = new string[] { "Input", "OK", "Cancel", "Must be filled in" };
    }

    public static string Show(string txt, string head, string s)
    {
        InputBox d = new InputBox(txt, head, s);
        if (d.ShowDialog() == DialogResult.OK)
            return d.box.Text.Trim();
        else
            return null;
    }

    public static string Show(string txt)
    {
        return Show(txt, str[0], "");
    }
}
