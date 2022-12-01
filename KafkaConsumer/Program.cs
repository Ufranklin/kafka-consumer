using System;
using System.Text.Json;
using System.Threading;
using Confluent.Kafka;
using KongConsumer;

namespace KafkaConsumer
{

    
     public class KafkaEvent
    {
        public string logtype { get; set; } = string.Empty;
        public string event_id { get; set; }= string.Empty;
        public string status { get; set; }= string.Empty;
        public string client_id { get; set; }= string.Empty;
        public string client_name { get; set; }= string.Empty;
        public string remote_ip { get; set; }= string.Empty;
        public string city { get; set; }= string.Empty;
        public string country { get; set; }= string.Empty;
        public string bvn { get; set; }= string.Empty;
        public string timestamp { get; set; }= string.Empty;
    }
    class Program
    {
        static void Main()
        {
            var conf = new ConsumerConfig
            { 
                GroupId = "test-consumer-group191",
                //BootstrapServers = "bvn-consent.nibss-plc.com.ng:9092",
                BootstrapServers = "10.91.91.180:9092",
                AutoOffsetReset = AutoOffsetReset.Latest
            };

            using var c = new ConsumerBuilder<Ignore, string>(conf).Build();
            c.Subscribe("gluu_oxauthscript");
             //c.Subscribe("bvndataretrieval-logs");
            //c.Subscribe("kong-bvn");
             //c.Subscribe("forex-logs");

            // Because Consume is a blocking call, we want to capture Ctrl+C and use a cancellation token to get out of our while loop and close the consumer gracefully.
            var cts = new CancellationTokenSource();
                  Console.CancelKeyPress += (_, e) => {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                while (true)
                {
                    // Consume a message from the test topic. Pass in a cancellation token so we can break out of our loop when Ctrl+C is pressed
                    var cr = c.Consume(cts.Token);
                    var logStr = cr.Value;
                    var kEvent = new KafkaEvent();
                    //var kongLog = new KongLog();

                    if(logStr.Contains("INFO") && logStr.Contains("logtype")){
                        logStr = logStr.Split(") - ")[1];
                        if(!string.IsNullOrWhiteSpace(logStr))
                            kEvent = JsonSerializer.Deserialize<KafkaEvent>(logStr);
                    }

                       //if(!string.IsNullOrWhiteSpace(logStr))
                            //kongLog = JsonSerializer.Deserialize<KongLog>(logStr);

                     

                    Console.WriteLine($"'{logStr}'");
                    //Console.WriteLine($"Consumed message '{logStr}' from topic {cr.Topic}, partition {cr.Partition}, offset {cr.Offset}");

                    // Do something interesting with the message you consumed
                }
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                c.Close();
            }
        }
    }
}