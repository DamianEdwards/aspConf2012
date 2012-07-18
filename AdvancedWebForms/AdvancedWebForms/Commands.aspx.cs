using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvancedWebForms
{
    public partial class Commands : CommandPage
    {
        // No code-behind in my page

    }


    public class UpdateLabelCommand : ICommand
    {
        public void Execute(Page page, Control source, object argument)
        {
            var target = source.NamingContainer.FindControl((string)argument) as Label;
            if (target == null)
            {
                return;
            }
            target.Text = "I was updated by the UpdateLabelCommand via a " + source.GetType().Name;
        }
    }

    public interface ICommand
    {
        void Execute(Page page, Control source, object argument);
    }

    public abstract class CommandPage : System.Web.UI.Page
    {
        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            var commandEventArgs = args as CommandEventArgs;
            if (commandEventArgs != null)
            {
                // Find the ICommand
                var commandType = BuildManager.GetType(commandEventArgs.CommandName + "Command", false);
                if (commandType == null)
                {
                    return base.OnBubbleEvent(source, args);
                }

                var command = Activator.CreateInstance(commandType) as ICommand;
                if (commandType == null)
                {
                    return base.OnBubbleEvent(source, args);
                }

                command.Execute(this, source as Control, commandEventArgs.CommandArgument);

                // We handled the event, stop bubbling
                return true;
            }
            return base.OnBubbleEvent(source, args);
        }
    }
}