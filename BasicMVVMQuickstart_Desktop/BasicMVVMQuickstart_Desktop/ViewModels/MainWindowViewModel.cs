// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using BasicMVVMQuickstart_Desktop.Model;
using Microsoft.Practices.Prism.Commands;

namespace BasicMVVMQuickstart_Desktop.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            SubmitCommand = new DelegateCommand<object>(OnSubmit);
            QuestionnaireViewModel = new QuestionnaireViewModel();
            ResetCommand = new DelegateCommand(OnReset);
        }

        public ICommand SubmitCommand { get; private set; }

        public ICommand ResetCommand { get; private set; }

        public QuestionnaireViewModel QuestionnaireViewModel { get; set; }

        private void OnSubmit(object obj)
        {
            Debug.WriteLine(BuildResultString());
        }

        private void OnReset()
        {
            QuestionnaireViewModel.Questionnaire = new Questionnaire();
        }

        private string BuildResultString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Name: ");
            builder.Append(QuestionnaireViewModel.Questionnaire.Name);
            builder.Append("\nAge: ");
            builder.Append(QuestionnaireViewModel.Questionnaire.Age);
            builder.Append("\nQuestion 1: ");
            builder.Append(QuestionnaireViewModel.Questionnaire.Quest);
            builder.Append("\nQuestion 2: ");
            builder.Append(QuestionnaireViewModel.Questionnaire.FavoriteColor);
            return builder.ToString();
        }
    }
}
