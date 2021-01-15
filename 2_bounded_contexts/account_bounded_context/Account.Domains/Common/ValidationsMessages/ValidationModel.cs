using System.Collections.Generic;
using System.Text;

namespace Account.Domains.Common.ValidationsMessages
{
    public sealed class ValidationModel
    {
        public ValidationModel()
        {
            this.ErrorsMessages = new List<string>();
            this.IsValid = true;
        }

        public bool IsValid { get; private set; }
        public List<string> ErrorsMessages { get; private set; }

        public string GetValidationErrorMessages(string initalMessage = "")
        {
            if (IsValid)
                return string.Empty;

            var msg = new StringBuilder();

            if (string.IsNullOrEmpty(initalMessage) == false)
            {
                msg.AppendLine(initalMessage);
            }
            foreach (var errorMessage in this.ErrorsMessages)
            {
                msg.AppendLine(errorMessage);
            }

            return msg.ToString();
        }

        public void AddValidationError(string msg)
        {
            this.IsValid = false;
            this.ErrorsMessages.Add(msg);
        }
    }
}