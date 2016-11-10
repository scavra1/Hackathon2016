using System;
using System.ComponentModel;


namespace ProjektJA
{
    /// <summary>
    /// Class represents data context of window application
    /// Every control that is seen in the window has its own representation
    /// in the class.
    /// Stores the controls data.
    /// </summary>
    class Model : INotifyPropertyChanged
    {
        private String inputPath;
        private String outputPath;
        private String password;
        private String elapsedTime;
        private bool masmLibrary;
        private bool cppLibrary;

        /// <summary>
        /// Default Constructor: Initializes Textboxes of window with empty strings.
        /// </summary>
        public Model()
        {
            inputPath = String.Empty;
            outputPath = String.Empty;
            password = String.Empty;
        }

        /// <summary>
        /// InputPath public accessor
        /// Enables flow of data from model to window's "Input Path" textbox and back
        /// </summary>
        public String InputPath
        {
            get { return inputPath; }
            set
            {
                inputPath = value;
                OnPropertyChanged("InputPath");
            }
        }

        /// <summary>
        /// OutputPath public accessor
        /// Enables flow of data from model to window's "Output Path" textbox and back
        /// </summary>

        public String OutputPath
        {
            get { return outputPath; }
            set
            {
                outputPath = value;
                OnPropertyChanged("OutputPath");
            }
        }

        /// <summary>
        /// Password public acccessor
        /// Enables flow of data from model to window's "Password" textbox and back
        /// </summary>
        public String Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        /// <summary>
        /// ElapasedTime public accessor
        /// Enables flow of data from model to window's "Time Elapased" textbox and back
        /// </summary>
        public String ElapsedTime
        {
            get { return elapsedTime; }
            set
            {
                elapsedTime = value;
                OnPropertyChanged("ElapsedTime");
            }
        }

        /// <summary>
        /// MasmLibrary public accessor
        /// Enables flow of data from model to window's "Masm DLL" radiobutton and back
        /// </summary>
        public bool MasmLibrary
        {
            get { return masmLibrary; }
            set { masmLibrary = value; OnPropertyChanged("MasmLibrary"); }
        }


        /// <summary>
        /// CppLibrary public accessor
        /// Enables flow of data from model to window's "Cpp DLL" radiobutton and back
        /// </summary>
        public bool CppLibrary
        {
            get { return cppLibrary; }
            set { cppLibrary = value; OnPropertyChanged("CppLibrary"); }
        }


        /// <summary>
        /// Implementation of INotifyPropertyChanged interface that enables data binding between model's data
        /// and window view.
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
