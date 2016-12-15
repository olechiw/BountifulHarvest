using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;


//
// Constants - A class containing the constant value of all important things
//

namespace Common
{
    // Somewhere to put all of the SqlConstants neatly
    public static class Constants
    {
        // Available tables in the database
        public static class Tables
        {
            public static string Patrons = "Patrons";
            public static string Visits = "Visits";
        }

        #region Constant Indexes of All SqlColumns, as Enums

        // Patrons table
        public enum PatronIndexes
        {
            FirstName,
            MiddleInitial,
            LastName,
            Gender,
            Family,
            DateOfLastVisit,
            DateOfBirth,
            Address,
            PhoneNumber,
            Comments,
            InitialVisitDate
        }

        // Visits table
        public enum VisitIndexes
        {
            FirstName,
            MiddleInitial,
            LastName,
            TotalPounds,
            DateOfVisit,
            VisitID
        }

        #endregion

        public static bool IsBeforeDate(string date, string lastDate)
        {
            string[] previousDate = lastDate.Split('/');

            int prevMonth = SafeConvertInt(previousDate[0]);
            int prevDay = SafeConvertInt(previousDate[1]);
            int prevYear = SafeConvertInt(previousDate[2]);

            string[] newDate = date.Split('/');

            int newMonth = SafeConvertInt(newDate[0]);
            int newDay = SafeConvertInt(newDate[1]);
            int newYear = SafeConvertInt(newDate[2]);

            if (newYear < prevYear)
                return false;
            else if (newMonth < prevMonth)
                return false;
            else if (newDay < prevDay)
                return false;
            else
                return true;
        }

        public static int SafeConvertInt(string s)
        {
            int i = 0;
            try
            {
                i = Convert.ToInt32(s);
            }
            catch (Exception)
            {

            }
            return i;
        }

        public static DateTime SafeConvertDate(string s)
        {
            DateTime d = new DateTime();
            try
            {
                d = Convert.ToDateTime(s);
            }
            catch (Exception)
            {

            }
            return d;
        }
    }

    //
    // http://www.albahari.com/nutshell/predicatebuilder.aspx
    //
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());

            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
}