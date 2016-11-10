using System;
using System.Windows.Input;



namespace ProjektJA
{
    /// <summary>
    /// This file stores Command operation definition 
    /// Command are used to invoke methods that are triggered when 
    /// either Encode or Decode button is clicked
    /// Commands implement ICommand interface that enables them to 
    /// poll data context to see if button can be executed (can be clicked)
    ///  </summary>
    class EncodeCommand : ICommand
    {
        /// <summary>
        /// stores viewmodel instance
        /// </summary>
        private ViewModel viewModel;

        /// <summary>
        /// Constructor: Initializes viewmodel data context
        /// </summary>
        /// <param name="viewModel"> instance of viewmodel used in window context </param>
        public EncodeCommand(ViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        #region ICommand Interface Implementation
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        /// <summary>
        /// pools data context to see if button can be clicked(is enabled or disabled)
        /// </summary>
        /// <param name="parameter">This parameter is optional and is not used by me</param>
        /// <returns>boolean value if button is enabled or should be disabled</returns>
        public bool CanExecute(object parameter)
        {
            return viewModel.CanEncodeDecodeExecute();
        }
        /// <summary>
        /// Performs Execute(Encode) operation if button is clicked and data context is correctly filled.
        /// See CanExecute method to get more details.
        /// </summary>
        /// <param name="parameter">This parameter is optional and is not used by me</param>
        public void Execute(object parameter)
        {

            // encoding operation
            throw new NotImplementedException();
        }

        #endregion
    }


    class DecodeCommand : ICommand
    {
        /// <summary>
        /// stores viewmodel instance
        /// </summary>
        private ViewModel viewModel;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="viewModel">instance of viewmodel used in window context</param>
        public DecodeCommand(ViewModel viewModel)
        {
            this.viewModel = viewModel;
        }


        #region ICommand Interface Implementation
        /// <summary>
        /// CanExecutedChanged event definition
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        /// <summary>
        /// pools data context to see if button can be clicked(is enabled or disabled)
        /// </summary>
        /// <param name="parameter">This parameter is optional and is not used by me</param>
        /// <returns>boolean value if button is enabled or should be disabled</returns>
        public bool CanExecute(object parameter)
        {
            return viewModel.CanEncodeDecodeExecute();
        }


        /// <summary>
        /// Performs Execute(Decode) operation if button is clicked and data context is correctly filled.
        /// See CanExecute method to get more details.
        /// </summary>
        /// <param name="parameter">This parameter is optional and is not used by me</param>
        public void Execute(object parameter)
        {
            //decoding operation
            throw new NotImplementedException();
        }

        #endregion
    }
}
