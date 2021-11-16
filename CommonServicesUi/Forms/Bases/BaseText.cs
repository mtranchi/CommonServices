using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonServicesUi.Forms.Bases
{
    public abstract class BaseText : BaseSelectable<string>
    {
        #region fields

        protected int charactersRemaining { get; set; }

        protected string maxLengthCss = "text-muted font-italic small";

        #endregion //fields

        [Parameter] public int MaxLength { get; set; }
        

        protected override void OnInitialized()
        {
            if (MaxLength > 0) setMaxLength();

            base.OnInitialized();
        }

#pragma warning disable CS8765
        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
#pragma warning restore CS8765
        {
            result = value;
#pragma warning disable CS8625
            validationErrorMessage = null;
#pragma warning restore CS8625
            return true;
        }

        #region helpers

        protected void displayCharactersRemaining(string value)
        {
            if (value != null) charactersRemaining = MaxLength - value.Length;

            if (charactersRemaining < 1) maxLengthCss = "text-danger font-weight-bold";
            else maxLengthCss = "text-muted font-italic small";
        }

        protected int getMaxlengthAttributeValue()
        {
            if (MaxLength > 0) return MaxLength;
            return int.MaxValue;
        }

        void setMaxLength()
        {
            if (string.IsNullOrEmpty(CurrentValue)) charactersRemaining = MaxLength;
            else
            {
                charactersRemaining = MaxLength - CurrentValue.Length;
            }
        }

        #endregion
    }
}
