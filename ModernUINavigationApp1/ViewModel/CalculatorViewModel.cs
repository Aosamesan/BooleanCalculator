using BooleanCalculatorLib;
using System;
using System.Data;

namespace BooleanCalculator.ViewModel
{
    public class CalculatorViewModel : NotifyPropertyChanged
    {
        private DataTable dt;
        private BooleanResultSet ResultSet
        {
            get; set;
        }

        public DataTable ResultArray
        {
            get
            {
                return dt;
            }
        }

        public string Expression
        {
            get;
            protected set;
        }

        public CalculatorViewModel()
        {
            dt = new DataTable();
            UpdateDataTable();
        }

        public void Calculate(string expr)
        {
            if (string.IsNullOrWhiteSpace(expr))
                return;
            ResultSet = BooleanCalculatorLib.BooleanCalculator.Calculate(expr);
            Expression = expr;
            UpdateDataTable();
            RaisePropertyChanged(nameof(ResultArray));
            RaisePropertyChanged(nameof(Expression));
        }

        protected void UpdateDataTable()
        {
            dt.Dispose();
            dt = new DataTable();
            if (ResultSet.NumOfSymbols > 0)
            {
                dt.Columns.Add("Number");
                foreach (char head in ResultSet.TokenSymbols)
                {
                    dt.Columns.Add($"{head}");
                }
                dt.Columns.Add("Result");
                int rows = 1 << ResultSet.NumOfSymbols;
                object[] param = new object[ResultSet.NumOfSymbols + 2];
                for (int i = 0; i < rows; i++)
                {
                    param[0] = i;
                    for (int j = 1; j < ResultSet.NumOfSymbols + 1; j++)
                        param[j] = ResultSet.AnswerSheet[i, j - 1];
                    param[ResultSet.NumOfSymbols + 1] = ResultSet.AnswerSheet[i, ResultSet.NumOfSymbols];
                    dt.Rows.Add(param);
                }
            }
            else
            {
                dt.Columns.Add("Result");
                dt.Rows.Add("Fail");
            }
            GC.Collect();
        }
    }
}
