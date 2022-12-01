using System.Text.Json.Serialization;

namespace KongConsumer
{
    public class AuthenticatedEntity
    {
        public string id { get; set; } = string.Empty;
    }

    public class Headers
    {
        [JsonPropertyName("content-type")]
        public string ContentType { get; set; }=string.Empty;

        [JsonPropertyName("x-credential-scope")]
        public string XCredentialScope { get; set; }=string.Empty;

       
         [JsonPropertyName("x-credential-client-id")]
        public string XCredentialClientId { get; set; }=string.Empty;

        [JsonPropertyName("user-agent")]
        public string UserAgent { get; set; }=string.Empty;

        [JsonPropertyName("x-credential-token-type")]
        public string XCredentialTokenType { get; set; }=string.Empty;

        [JsonPropertyName("x-credential-exp")]
        public string XCredentialExp { get; set; }=string.Empty;

        [JsonPropertyName("x-credential-iat")]
        public string XCredentialIat { get; set; }=string.Empty;

        [JsonPropertyName("x-credential-sub")]
        public string XCredentialSub { get; set; }=string.Empty;

        [JsonPropertyName("x-credential-aud")]
        public string XCredentialAud { get; set; }=string.Empty;

        [JsonPropertyName("x-credential-iss")]
        public string XCredentialIss { get; set; }=string.Empty;

        [JsonPropertyName("x-consumer-unique-id")]
        public string XConsumerUniqueId { get; set; }=string.Empty;
        public string host { get; set; }=string.Empty;
        public string connection { get; set; }=string.Empty;

        [JsonPropertyName("postman-token")]
        public string PostmanToken { get; set; }=string.Empty;

        [JsonPropertyName("accept-encoding")]
        public string AcceptEncoding { get; set; }=string.Empty;

        [JsonPropertyName("x-consumer-custom-id")]
        public string XConsumerCustomId { get; set; }=string.Empty;

        [JsonPropertyName("x-transaction-id")]
        public string XTransactionId { get; set; }=string.Empty;

        [JsonPropertyName("x-credential-jti")]
        public string XCredentialJti { get; set; }=string.Empty;

        [JsonPropertyName("x-credential-username")]
        public string XCredentialUsername { get; set; }=string.Empty;
        public string accept { get; set; }=string.Empty;

        [JsonPropertyName("content-length")]
        public string ContentLength { get; set; }=string.Empty;

        [JsonPropertyName("expect-ct")]
        public string ExpectCt { get; set; }=string.Empty;

        [JsonPropertyName("access-control-allow-origin")]
        public string AccessControlAllowOrigin { get; set; }=string.Empty;

        [JsonPropertyName("cache-control")]
        public string CacheControl { get; set; }=string.Empty;

        [JsonPropertyName("content-security-policy")]
        public string ContentSecurityPolicy { get; set; }=string.Empty;

        [JsonPropertyName("feature-policy")]
        public string FeaturePolicy { get; set; }=string.Empty;

        [JsonPropertyName("strict-transport-security")]
        public string StrictTransportSecurity { get; set; }=string.Empty;

        [JsonPropertyName("x-xss-protection")]
        public string XXssProtection { get; set; }=string.Empty;
        public string date { get; set; }=string.Empty;

        [JsonPropertyName("x-content-type-options")]
        public string XContentTypeOptions { get; set; }=string.Empty;

        [JsonPropertyName("referrer-policy")]
        public string ReferrerPolicy { get; set; }=string.Empty;

        [JsonPropertyName("x-frame-options")]
        public string XFrameOptions { get; set; }=string.Empty;

        [JsonPropertyName("transfer-encoding")]
        public string TransferEncoding { get; set; }=string.Empty;

        [JsonPropertyName("x-permitted-cross-domain-policies")]
        public string XPermittedCrossDomainPolicies { get; set; }=string.Empty;
    }

    public class Latencies
    {
        public int request { get; set; }
        public int proxy { get; set; }
        public int kong { get; set; }
    }

    public class Querystring
    {
    }

    public class Request
    {
        public int size { get; set; }
        public Headers headers { get; set; } =new Headers();
        public string uri { get; set; }=string.Empty;
        public string url { get; set; }=string.Empty;
        public string method { get; set; }=string.Empty;
        public Querystring querystring { get; set; }=new Querystring();
    }

    public class Response
    {
        public int status { get; set; }
        public Headers headers { get; set; } =new Headers();
        public int size { get; set; }
    }

    public class KongLog
    {
        public string upstream_uri { get; set; }=string.Empty;
        public List<Try> tries { get; set; } =new List<Try>();
        public string workspace { get; set; }=string.Empty;
        public Route route { get; set; } = new Route();
        public Service service { get; set; } = new Service();
        public Latencies latencies { get; set; } =new Latencies();
        public string client_ip { get; set; }=string.Empty;
        public AuthenticatedEntity authenticated_entity { get; set; }=new AuthenticatedEntity();
        public long started_at { get; set; }
        public Request request { get; set; }=new Request();
        public Response response { get; set; } = new Response();
    }

    public class Route
    {
        public List<string> protocols { get; set; }  = new List<string>();
        public int regex_priority { get; set; }
        public List<string> paths { get; set; } = new List<string>();
        public List<string> methods { get; set; } = new List<string>();
        public bool request_buffering { get; set; }
        public bool response_buffering { get; set; }
        public string name { get; set; } = string.Empty;
        public bool strip_path { get; set; }
        public string id { get; set; }= string.Empty;
        public string ws_id { get; set; }= string.Empty;
        public bool preserve_host { get; set; }
        public string path_handling { get; set; }= string.Empty;
        public int https_redirect_status_code { get; set; }
        public Service service { get; set; }= new Service();
        public int created_at { get; set; }
        public int updated_at { get; set; }
    }

    public class Service
    {
        public string id { get; set; }
        public int port { get; set; }
        public string ws_id { get; set; }
        public bool enabled { get; set; }
        public string protocol { get; set; }
        public int updated_at { get; set; }
        public string path { get; set; }
        public int connect_timeout { get; set; }
        public int retries { get; set; }
        public int read_timeout { get; set; }
        public string host { get; set; }
        public int created_at { get; set; }
        public int write_timeout { get; set; }
        public string name { get; set; }
    }

    public class Try
    {
        public int port { get; set; }
        public long balancer_start { get; set; }
        public string ip { get; set; }
        public int balancer_latency { get; set; }
    }



}