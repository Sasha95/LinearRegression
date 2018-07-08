using System;
using System.Windows.Forms;


namespace LinearRegression
{
    public partial class LinearRegression : Form
    {
        public LinearRegression()
        {
            InitializeComponent();            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear(); //очищаем график, чтоб при новом клике на кнопку стирался предыдущий график
            chart1.Series[1].Points.Clear();
            int n = 30;  //кол-во точек в массиве. Тут сделай под себя, это значение может меняться динамически. Главное, чтоб кол-во X и Y было одинаковым

            double[] xVals = new double[n];
            double[] yVals = new double[n];

            Random rnd = new Random();

            for (int i = 0; i < n; i++) 
            {
                xVals[i] = i; //задаем массив X
                yVals[i] = i + rnd.Next(-5, 5);//задаем некоторое отклонение от прямой, это наш массив Y
            }

            SimpleLinearRegression slr = new SimpleLinearRegression(xVals, yVals); //Создаем экземпляр класса и передаем в конструктор созданные выше массивы X и Y 

            for (int i = 0; i < yVals.Length; i++)
            {
                chart1.Series[0].Points.AddXY(xVals[i], yVals[i]); //рисуем точки с некоторым отклонением от прямой (их задали выше)
                chart1.Series[1].Points.AddXY(xVals[i], slr.PredictY(i)); //рисуем те же X и предсказанные Y
            }           
        }
    }
}
