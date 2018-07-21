using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eLearning.DAL.MakerChecker
{
    public class Script
    {
        private const string transaction_template = @"
        BEGIN TRY  
	        BEGIN TRANSACTION;

	        {0}

	        COMMIT;
        END TRY  
        BEGIN CATCH  
             ROLLBACK;
             THROW SELECT ERROR_MESSAGE();
        END CATCH  ";

        private StringBuilder Scripts { get; set; }

        public Script()
        {
            this.Scripts = new StringBuilder();
        }

        public Script(String commentText)
        {
            this.Scripts = new StringBuilder();
            this.Comment(commentText);
        }

        public void Comment(string text)
        {
            this.Scripts.AppendLine("/* " + text + " */" + "\n");
        }
        public void Collect(string sql)
        {
            this.Scripts.AppendLine(sql + "\n");
        }
        public void Collect(Script script)
        {
            this.Scripts.Append(script.ToString());
        }

        public static Script operator +(Script to, string from)
        {
            to.Collect(from);
            return to;
        }
        public static Script operator +(Script to, Script from)
        {
            to.Collect(from);
            return to;
        }

        public override string ToString()
        {
            return this.Scripts.ToString();
        }
        public string ToString(bool wrapInTransaction)
        {
            if (wrapInTransaction)
                return String.Format(transaction_template, this.Scripts.ToString());
            else
                return this.Scripts.ToString();
        }
    }
}
