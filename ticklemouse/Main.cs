namespace ticklemouse
{
    using Gtk;
    using System;
    using System.Timers;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using HelperClassesBJH;

    public class MainWindow
    {
        #region CONSTANT FIELDS
        #endregion
        #region FIELDS
        Timer tmr_tickle;
        Timer tmr_length;
        #region GLADE FIELDS
        #pragma warning disable 169     // Disable the "object never used" warning.  This warning happens when we are using controls that are generated via the Glade file.
        #pragma warning disable 649
        #region WINDOWS
        [Builder.Object] private Window wnd_tickle_mouse;
        #endregion
        #region SPIN BUTTONS
        [Builder.Object] private SpinButton sbn_length_of_tickle;
        [Builder.Object] private SpinButton sbn_frequency_of_tickle;
        [Builder.Object] private SpinButton sbn_size_of_tickle;
        [Builder.Object] private ProgressBar prg_remaining;
        #endregion
        #region SPINNERS
        [Builder.Object] private Spinner spinner1;
        #endregion
        #region TOGGLE BUTTONS
        [Builder.Object] private ToggleButton tgl_tickle;
        #endregion
        #pragma warning restore 169
        #pragma warning restore 649
        #endregion
        int length;
        #endregion
        #region CONSTRUCTORS
        public MainWindow()
        {
            Gtk.Application.Init();
            Builder Gui = new Builder();
            Gui.AddFromFile("../../Resources/GUI.glade");
            Gui.Autoconnect(this);
            //Gtk.Settings.Default.ThemeName = "VimixDark";
            //Gtk.CssProvider css_provider = new Gtk.CssProvider();
            //css_provider.LoadFromPath("../../Resources/OLTRAtheme/gtk.css");
            //Gtk.StyleContext.AddProviderForScreen(Gdk.Screen.Default, css_provider, 800);
            GLib.Idle.Add(Startup); // run the Startup method next time application is idle.
            Gtk.Application.Run();
        }
        #endregion
        #region DESTRUCTORS
        #endregion
        #region DELEGATES
        #endregion
        #region EVENTS
        #endregion
        #region ENUMS
        #endregion
        #region INTERFACES
        #endregion
        #region PROPRERTIES
        public Settings TickleMouseSettings { get; set;}
        public string Home { get; set;}
        public string SettingsFile { get; set; }
        #endregion
        #region INDEXERS
        #endregion
        #region METHODS
        public static void Main()
        {
            new MainWindow();
        }
        private bool Startup()
        {
            // Put startup actions here.
            ConsoleMessage.WriteLine("Starting up!");
            ConsoleMessage.WriteLine("Running initial startup routine.");
            ConsoleMessage.WriteLine("Detected platform: " + Environment.OSVersion.Platform.ToString());

            /* INSTANTIATE SETTINGS AND DETECT PLATFORM */
            TickleMouseSettings = new Settings();
            /* FIND HOME DIRECTORY */
            string path = Environment.GetEnvironmentVariable("HOME", EnvironmentVariableTarget.Process);   
            if (String.IsNullOrEmpty(path))
            {
                ConsoleMessage.WriteLine("Home directory not set!");
                  
                ResponseType r = MessageBox.Show("$HOME environment variable not set!\nPress OK to set it up now.\nPress Cancel to abort, but application will not store any settings.", type: MessageType.Error, buttonsType: ButtonsType.OkCancel);
                if (r == ResponseType.Ok)
                {
                    FileChooserDialog fc = new FileChooserDialog("Choose HOME directory", null, FileChooserAction.SelectFolder, "Cancel", ResponseType.Cancel, "OK", ResponseType.Accept);
                    if (fc.Run() == (int)ResponseType.Accept)
                    {
                        Environment.SetEnvironmentVariable("HOME", fc.Filename, EnvironmentVariableTarget.Machine);
                    }
                    fc.Destroy();
                }

                else
                {
                    ConsoleMessage.WriteLine("Home directory setting cancelled - application will exit!");
                    Application.Quit();
                }
            }
            else
            {
                ConsoleMessage.WriteLine("Home directory found: " + path);
                Home = path;
                SettingsFile = Home + "/" + ".ticklemouse";
            }
            /* LOAD EXISTING SETTINGS */
            if (File.Exists(SettingsFile))
            {
                // Load Settings
                ConsoleMessage.WriteLine("Loading ticklemouse settings");
                try
                {
                    IFormatter bf = new BinaryFormatter();
                    using (FileStream fs = File.OpenRead(SettingsFile))
                    {
                        Settings s = (Settings)bf.Deserialize(fs);
                        TickleMouseSettings = s;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Failed to deserialise settings file\n" + ex.Message + "\nApplication will now quit!", MessageType.Error);
                    Application.Quit();
                }
                finally
                {
                    //ConsoleMessage.WriteLine("Settings successfully loaded.  Project Directory: " + TickleMouseSettings.ProjectDir + "\n");

                }
            }
            else
            {
                // Default Settings
                ConsoleMessage.WriteLine("ticklemouse settings not found, creating default", MessageType.Warning);

                ConsoleMessage.WriteLine("Writing default settings to: " + SettingsFile);
                try
                {
                    IFormatter bf = new BinaryFormatter();
                    using (FileStream fs = File.Create(SettingsFile))
                        bf.Serialize(fs, TickleMouseSettings);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Failed to write default settings! Error:\n" + ex.Message + " Application will now quit", MessageType.Error);
                    Application.Quit();
                }
            }
            double size, length, freq;
            size = TickleMouseSettings.TickleSize;
            length = TickleMouseSettings.TickleLength;
            freq = TickleMouseSettings.TickleFrequency;
            sbn_size_of_tickle.Value = size;
            sbn_length_of_tickle.Value = length;
            sbn_frequency_of_tickle.Value = freq;

            ConsoleMessage.WriteLine("Setting up Tickle Frequency Timer");
            tmr_tickle = new Timer();
            if (TickleMouseSettings.TickleFrequency > 0)
            {
                tmr_tickle.Interval = (TickleMouseSettings.TickleFrequency * 1000);
                ConsoleMessage.WriteLine("Tickle Frequency Timer interval set to: " + tmr_tickle.Interval.ToString());
            }
            tmr_length = new Timer();
            tmr_length.Interval = 1000;    // Tick every minute.

            tmr_tickle.Elapsed += new ElapsedEventHandler(on_tmr_tickle_tick);
            tmr_length.Elapsed += new ElapsedEventHandler(on_tmr_length_tick);
            return false;
        }
        public bool CloseApplication()
        {
            Application.Quit();
            return true;
        }
        private void WriteSettings()
        {
            ConsoleMessage.WriteLine("Writing settings to: " + SettingsFile);
            try
            {
                IFormatter bf = new BinaryFormatter();
                using (FileStream fs = File.Create(SettingsFile))
                    bf.Serialize(fs, TickleMouseSettings);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to write default settings! Error:\n" + ex.Message, MessageType.Error);
            }
        }
        #region EVENT HANDLERS
        private void on_wnd_tickle_mouse_delete_event(object sender, DeleteEventArgs e)
        {
            WriteSettings();
            e.RetVal = CloseApplication();
            Application.Quit();
            string m = "OnDeleteEvent done: " + e.RetVal;
            ConsoleMessage.WriteLine(m);
            ConsoleMessage.WriteLine("Bye!");
        }
        private void on_tgl_tickle_toggled(object sender, EventArgs e)
        {
            ToggleButton t = (ToggleButton)sender;
            if (t.Active)
            {
                prg_remaining.Fraction = 0;
                if (TickleMouseSettings.TickleLength > 0)
                {
                    tmr_length.Start();
                    length = Convert.ToInt32(TickleMouseSettings.TickleLength);
                }
                tmr_tickle.Start();
                spinner1.Active = true;
            }
            else
            {
                prg_remaining.Fraction = 1;
                spinner1.Active = false;
                tmr_length.Enabled = false;
                tmr_tickle.Enabled = false;
            }
        }
        private void on_sbn_frequency_of_tickle_value_changed(object sender, EventArgs e)
        {
            SpinButton sbn = (SpinButton)sender;
            TickleMouseSettings.TickleFrequency = sbn.Value;
            ConsoleMessage.WriteLine("Frequency of tickle changed to: " + sbn.Value.ToString());
        }
        private void on_sbn_size_of_tickle_value_changed(object sender, EventArgs e)
        {
            SpinButton sbn = (SpinButton)sender;
            TickleMouseSettings.TickleSize = sbn.Value;
            ConsoleMessage.WriteLine("Size of tickle changed to: " + TickleMouseSettings.TickleSize.ToString());
        }
        private void on_sbn_length_of_tickle_value_changed(object sender, EventArgs e)
        {
            SpinButton sbn = (SpinButton)sender;
            TickleMouseSettings.TickleLength = sbn.Value;
            ConsoleMessage.WriteLine("Length of tickle changed to: " + TickleMouseSettings.TickleLength.ToString());
            length = Convert.ToInt32(sbn.Value);
        }
        private void on_tmr_tickle_tick(object sender, EventArgs e)
        {
            ConsoleMessage.WriteLine("tickle event!");
            int size = Convert.ToInt32(TickleMouseSettings.TickleSize);
            Tickler.MoveMouse(size, size);
        }
        private void on_tmr_length_tick(object sender, EventArgs e)
        {
            ConsoleMessage.WriteLine("tickle length event!");
            length -= 1;
            if (length >= 1)
            {
                ConsoleMessage.WriteLine(length.ToString() + " minutes left");
                double progress = (100 / (Convert.ToDouble(length))) / 100;
                prg_remaining.Fraction = (progress);
            }
            else
            {
                prg_remaining.Fraction = 1;
                tmr_tickle.Stop();
                tmr_tickle.Enabled = false;
                tmr_length.Stop();
                tmr_length.Enabled = false;
                if (tgl_tickle.Active)
                    tgl_tickle.Active = false;
                if (spinner1.Active)
                    spinner1.Active = false;
            }
        }
        #endregion
        #endregion
        #region STRUCTS
        #endregion
        #region CLASSES
        #endregion
    }
}

