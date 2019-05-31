using System;
using Gtk;
using image_view;

public partial class MainWindow : Gtk.Window
{
    // protected Gtk.FileChooserWidget FileChooserWidget;
    // protected Gtk.Image ImageView;
    // protected Gtk.Button PrevBtn;
    // protected Gtk.Button NextBtn;

    private PicturesPool picturesPool = new PicturesPool();

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        OnShownSetup();
    }

    protected void OnShownSetup()
    {
        // set up 
        FileFilter filter = new FileFilter();
        filter.Name = "PNG and JPEG images";
        filter.AddMimeType("image/png");
        filter.AddPattern("*.png");
        filter.AddMimeType("image/jpeg");
        filter.AddPattern("*.jpg");
        this.FileChooserWidget.Filter = filter;
        Console.WriteLine("setup");
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void onFolderChanged(object sender, EventArgs e)
    {
    }

    protected void onFileSelected(object sender, EventArgs e)
    {
        // get all in folder
        string filename = this.FileChooserWidget.Filename;
        string ext = "";
        if (String.IsNullOrWhiteSpace(filename) == false)
            ext = filename.Substring(Math.Max(0, filename.Length - 3));
        if (ext == "png" || ext == "jpg")
        {
            if (picturesPool.SetPool(this.FileChooserWidget.Filename) > -1)
            { 
                this.ImageView.File = picturesPool.GetCurrent();
            }
        }
    }

    protected void OnNextClick(object sender, EventArgs e)
    {
        Console.WriteLine("next");
        this.ImageView.File = picturesPool.GetNext();
    }

    protected void OnPrevClick(object sender, EventArgs e)
    {
        Console.WriteLine("prev");
        this.ImageView.File = picturesPool.GetPrev();
    }
}
