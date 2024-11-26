namespace Immo.CSharp.AsyncExample
{
    public class AsyncOperation1
    {
        public async Task GetData1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    Task.Delay(100);
                    Console.WriteLine($"Task 1 :{i}");
                }
            });
        }

        public async Task GetData2()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    Task.Delay(100);
                    Console.WriteLine($"Task 2 :{i}");
                }
            });
        }
    }
}
