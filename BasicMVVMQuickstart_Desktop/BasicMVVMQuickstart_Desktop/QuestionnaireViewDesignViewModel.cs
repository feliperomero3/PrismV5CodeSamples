// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using BasicMVVMQuickstart_Desktop.ViewModels;

namespace BasicMVVMQuickstart_Desktop
{
    public class QuestionnaireViewDesignViewModel
    {
        public QuestionnaireViewDesignViewModel()
        {
            QuestionnaireViewModel = new QuestionnaireViewModel();
        }

        public QuestionnaireViewModel QuestionnaireViewModel { get; set; }
    }
}
