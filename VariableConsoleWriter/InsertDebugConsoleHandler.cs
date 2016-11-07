using System;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Editor;


namespace VariableConsoleWriter
{
	class InsertDebugConsoleHandler : CommandHandler
	{
		protected override void Run()
		{
			var textEditor = IdeApp.Workbench.ActiveDocument.GetContent<TextEditor>();

			var selectedString = textEditor.SelectedText;

			textEditor.ClearSelection();

			textEditor.CaretLine = textEditor.CaretLine + 1;
			textEditor.CaretColumn = 1;
			textEditor.InsertAtCaret(
				String.Format("System.Diagnostics.Debug.WriteLine({0}, System.Reflection.MethodBase.GetCurrentMethod().Name);{1}",
				              selectedString,
				              Environment.NewLine));
		}

		protected override void Update(CommandInfo info) 
			=> info.Enabled = IdeApp.Workbench.ActiveDocument.GetContent<TextEditor>().IsSomethingSelected;
	}
}
