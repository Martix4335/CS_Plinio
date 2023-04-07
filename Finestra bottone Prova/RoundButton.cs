using System.Drawing.Drawing2D;

public partial class RoundButton : Button
{
    public RoundButton()
    {

    }
    protected override void OnPaint(PaintEventArgs pevent)
    {
        GraphicsPath grp = new GraphicsPath();
        grp.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
        Region = new Region(grp);
        base.OnPaint(pevent);
    }
}