using Practica_1;
using Practica1;

internal class Program
{
    private static void Main(string[] args)
    {
        Taxi taxi1 = new Taxi("0001 AAA");
        Taxi taxi2 = new Taxi("0002 BBB");
        Police police1 = new Police("0001 CNP");
        Police police2 = new Police("0002 CNP");

        police1.PatrolStart();
        police1.measured_Speed(taxi1);

        taxi2.StartRide();
        police2.measured_Speed(taxi2);

        police2.PatrolStart();
        police2.measured_Speed(taxi2);
        taxi2.StopRide();
        police2.PatrolStop();

        taxi1.StartRide();
        taxi1.StartRide();

        police1.PatrolStart();
        police1.measured_Speed(taxi1);

        taxi1.StopRide();
        taxi1.StopRide();
        police1.PatrolStop();

        police1.SpeedHistory();
        police2.SpeedHistory();


    }
}