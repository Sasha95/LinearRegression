using System;
using System.Linq;

public class SimpleLinearRegression
{
    public double[] xVals, yVals;
    public double standardDevX, standardDevY, correlation, slope, interception; //стандартное отклонение X и Y, пирсонская корреляция, угол наклона графика, отступ от оси абсцисс по оси ординат 

    public SimpleLinearRegression(double[] xVals, double[] yVals)  //конструктор класса
    {
        this.xVals = xVals;
        this.yVals = yVals;
        standardDevX = GetStandardDeviation(xVals);
        standardDevY = GetStandardDeviation(yVals);
        correlation = GetCorrelation(xVals, yVals);
        //Это из теории
        slope = correlation * standardDevY / standardDevX;
        interception = GetArrMean(yVals) - slope * GetArrMean(xVals);
    }

    public double PredictY(double x) //предсказываем Y по X
    {
        return interception + slope * x;
    }

    private static double GetArrMean(double[] arr) //ср. значение
    {
        return arr.Sum() / arr.Length;
    }

    private static double GetStandardDeviation(double[] arr) //стандартное отклонение
    {
        double mean = GetArrMean(arr);
        double[] devs = new double[arr.Length]; 
        for (int i = 0; i < arr.Length; i++)
        {
            devs[i] = Math.Pow(arr[i] - mean, 2);
        }
        return Math.Sqrt(devs.Sum() / (devs.Length - 1));
    }

    private static double GetCorrelation(double[] X, double[] Y) //расчет корреляции
    {
        double XMean = X.Sum() / X.Length;
        double YMean = Y.Sum() / Y.Length;
        double[] x = new double[X.Length];
        double[] y = new double[Y.Length];

        for (int i = 0; i < X.Length; i++)
        {
            x[i] = X[i] - XMean;
            y[i] = Y[i] - YMean;
        }

        double[] xy = new double[X.Length];
        for (int i = 0; i < X.Length; i++)
        {
            xy[i] = x[i] * y[i];
        }

        double[] xPowed = new double[X.Length];
        double[] yPowed = new double[Y.Length];

        for (int i = 0; i < X.Length; i++)
        {
            xPowed[i] = Math.Pow(x[i], 2);
            yPowed[i] = Math.Pow(y[i], 2);
        }

        return xy.Sum() / Math.Sqrt(xPowed.Sum() * yPowed.Sum());
    }
}

