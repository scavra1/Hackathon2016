using System;
using System.Windows.Input;

namespace ProjektJA
{
    /// <summary>
    /// Viewmodel of application
    /// Performs entire window logic: checking path values, chosen library and enables 
    /// encoding and decoding operations.
    /// </summary>
    class ViewModel
    {
        /// <summary>
        /// Holds the data model infomation
        /// </summary>
        private Model _model;

        /// <summary>
        /// Constructor of ViewModel:
        /// creates data model context and Encode and Decode operations delegates
        /// </summary>
        public ViewModel()
        {
            _model = new Model();
            EncodeCommand = new EncodeCommand(this);
            DecodeCommand = new DecodeCommand(this);
        }

        /// <summary>
        /// public accessor to Model
        /// </summary>
        public Model Model
        {
            get { return _model; }
        }


        /// <summary>
        /// Property of EncodeCommand delegate
        /// </summary>
        public ICommand EncodeCommand { get; private set; }
        /// <summary>
        /// Property of DecodeCommand delegate
        /// </summary>
        public ICommand DecodeCommand { get; private set; }

        /// <summary>
        /// This method is used to check if all data context is correctly filled
        /// Checks if:
        /// * password is entered
        /// * input and output path is entered
        /// * either cpp or masm library radiobutton is checked
        /// </summary>
        /// <returns>boolean value if data context is correctly filled</returns>
        internal bool CanEncodeDecodeExecute()
        {
            return !(
                           String.IsNullOrWhiteSpace(Model.InputPath)
                        || String.IsNullOrWhiteSpace(Model.OutputPath)
                        || String.IsNullOrWhiteSpace(Model.Password))
                    && (Model.CppLibrary || Model.MasmLibrary);
        }
    }
}
