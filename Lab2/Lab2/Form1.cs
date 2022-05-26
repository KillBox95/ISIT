using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private WorkMemory workMemory;
        private string currentFactName;
        private int clicksCount, askedQuestionCount;
        private List<string> validAnswersList;

        public Form1()
        {
            InitializeComponent();
            clicksCount = 0;
            askedQuestionCount = 0;
            currentFactName = null;
            workMemory = new WorkMemory();
            SystemOutputTB.TabStop = false; // убирает фокус с текстбокса 
            SystemOutputTB.Text = "\r\n\r\n";
            UserAnswerBTN.Text = "Начать";
        }

        private bool AnswerTheQuestion() // отправка ответа пользователя
        {
            string answerValue = UserAnswerTB.Text;

            foreach (string variant in validAnswersList)
            {
                if (variant == answerValue)
                {
                    SystemOutputTB.AppendText(" " + answerValue);
                    workMemory.ResponseProcessing(currentFactName, answerValue);

                    SystemOutputTB.AppendText("\r\n\r\n");
                    UserAnswerTB.Focus();
                    UserAnswerTB.Clear();
                    return true;
                }
            }

            UserAnswerTB.Clear();
            MessageBox.Show("Введите один из предложенных вариантов ответа.");
            return false;
        }

        private void GetQuestion() // получение нового вопроса
        {
            // структура кортежа: 1 - текст вопроса, 2 - имя факта, которому соответствует текущий вопрос, 3 - список допустимых вариантов ответа
            Tuple<string, string, List<string>> result = workMemory.GetQuestionAndCurrentDefruleName();
            SystemOutputTB.AppendText(result.Item1);
            currentFactName = result.Item2;
            validAnswersList = result.Item3;
        }

        private void UserAnswerBTN_Click(object sender, EventArgs e)
        {

            if (++clicksCount == 1)
            {
                UserAnswerBTN.Text = "Ответить";
                UserAnswerTB.Enabled = true;
                GetQuestion();
            }
            else
            {
                if (UserAnswerTB.Text == string.Empty)
                    MessageBox.Show("Поле ввода не должно быть пустым.");
                else
                {
                    bool check = AnswerTheQuestion();
                    ++askedQuestionCount; // количество заданных вопросов для обработки случаев, когда система не может вывести ответ

                    Tuple<string, bool> corteg = workMemory.DefrulesEnumeration();
                    bool isFinal = corteg.Item2; // булевая переменная, возвращающая содержание факта типа "спорт" в РП


                    if (isFinal)
                    {
                        SystemOutputTB.AppendText("Система советует " + corteg.Item1);
                        UserAnswerBTN.Enabled = false;
                        return;
                    }
                    if (check)
                        GetQuestion();
                }
            }
        }

        private void YesRB_CheckedChanged(object sender, EventArgs e)
        {
            UserAnswerTB.Text = "да";
        }

        private void NoRB_CheckedChanged(object sender, EventArgs e)
        {
            UserAnswerTB.Text = "нет";
        }

        private void ExplanationComponentCallBtn_Click(object sender, EventArgs e)
        {
            string result = "Последовательность выведенных фактов: \r\n";

            foreach (var fact in workMemory.GetFactsList())
                result += "Имя факта: " + fact.Name + ", значение: " + fact.Value + "\r\n";

            MessageBox.Show(result);
        }

        private void SystemOutputTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserAnswerTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SystemResetBTN_Click(object sender, EventArgs e)
        {
            clicksCount = 0;
            askedQuestionCount = 0;
            currentFactName = string.Empty;
            workMemory.Clear();
            SystemOutputTB.Text = "\r\n\r\n";
            UserAnswerBTN.Text = "Начать";
            UserAnswerTB.Enabled = false;
            UserAnswerBTN.Enabled = true;
            UserAnswerTB.Clear();
        }
    }
}
