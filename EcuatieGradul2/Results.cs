using System.Windows.Forms;


namespace EcuatieGradul2
{
    public static class Results
    {
        public static Label[] Result = { };

        public static void ShowResults(Form form)
        {
            foreach (var res in Result)
            {
                form.Controls.Add(res);
            }
        }
    }
}