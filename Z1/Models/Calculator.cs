using System.ComponentModel.DataAnnotations;

namespace Z1.Models;

public class Calculator
{
    [Required]
    [Display(Name = "Działanie")]
    public Operators? Operator { get; set; }

    [Display(Name = "Liczba po lewej")]
    public decimal X { get; set; }
    [Display(Name = "Liczba po prawej")]
    public decimal Y { get; set; }

    public String Op
    {
        get
        {
            // dodaj przypadki dla każdego operatora
            switch (Operator)
            {
                case Operators.Add:
                    return "+";
                case Operators.Sub:
                    return "-";
                case Operators.Mul:
                    return "*";
                case Operators.Div:
                    return "/";
                default:
                    return "";
            }
        }
    }

    public double Calculate() {
        switch (Operator)
        {
            // uzupełnij o pozostałe operatory
            case Operators.Add:
                return (double) (X + Y);
            case Operators.Sub:
                return (double) (X - Y);
            case Operators.Mul:
                return (double) (X * Y);
            case Operators.Div:
                return (double) (X / Y);
            default: return double.NaN;
        }
    }
}