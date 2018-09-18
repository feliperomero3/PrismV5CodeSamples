// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Practices.Prism.Mvvm;
using BasicMVVMQuickstart_Desktop.Model;

namespace BasicMVVMQuickstart_Desktop.ViewModels
{
    public class QuestionnaireViewModel : BindableBase
    {
        private Questionnaire _questionnaire;

        public QuestionnaireViewModel()
        {
            Questionnaire = new Questionnaire();
            AllColors = new[] { "Red", "Blue", "Green" };
        }

        public Questionnaire Questionnaire
        {
            get { return _questionnaire; }
            set { SetProperty(ref _questionnaire, value); }
        }

        public IEnumerable<string> AllColors { get; private set; }

    }
}
