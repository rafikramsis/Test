<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WeatherControl.ascx.cs"
    Inherits="WeatherControl" %>
<div id="weather">
    <h2  id="location">
        Weather in Gran Canaria
    </h2>
    <div id="temerature">
        <img src="#" alt="" id="imgWeatherFlag" />
        <span id="weatherDesc">
        </span>
        <span id="temp_C">
        </span>
    </div>
    <div id="wind">
        <span id="local_time"></span>
        <br />
        <span id="windspeedKmph"></span>
     
    </div>
    <div style="display:none;" id="nextday">
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {

        getWeather('<%= City %>', 'json', '<%= ForcastingDays %>', '<%= ApiKey %>');
    });
    var weekday = new Array(7);
    weekday[1] = "Sun"; //"Sunday";
    weekday[2] = "Mon"; //"Monday";
    weekday[3] = "Tue"; //"Tuesday";
    weekday[4] = "Wed"; //"Wednesday";
    weekday[5] = "Thu"; //"Thursday";
    weekday[6] = "Fri"; //"Friday";
    weekday[0] = "Sat"; //"Saturday";

    function getWeather(city, format, daysCount, apikey) {
        $.ajax({
            type: "GET",
            url: 'http://free.worldweatheronline.com/feed/weather.ashx?q=' + city + '&format=' + format + '&num_of_days=' + daysCount + '&key=' + apikey,
            contentType: "application/json; charset=utf-8",
            dataType: "jsonp",
            error: function (msg) {
                alert(msg);
            },
            success: function (msg) {
                //$("#location").text('<%= CityTitle %> - <%= CountryTitle %>');
                $("#temp_C").html(msg.data.current_condition[0].temp_C + "&deg; C");
                $("#local_time").text("Local Time:" + '<%=  DateTime.UtcNow.AddHours(2).ToShortTimeString() %>');
                //$("#local_time").text(msg.data.current_condition[0].observation_time);
                $("#weatherDesc").text(msg.data.current_condition[0].weatherDesc[0].value);
                $("#windspeedKmph").text("Wind Speed: " + msg.data.current_condition[0].windspeedKmph + ' Km/h');
                //$("#winddir16Point").text("Wind Direction: " + msg.data.current_condition[0].winddir16Point);
                $("#imgWeatherFlag").attr("src", msg.data.current_condition[0].weatherIconUrl[0].value.replace("http://www.worldweatheronline.com/images/wsymbols01_png_64/wsymbol_", "images/Weather Symbols/wsymb8_"));
                $("#imgWeatherFlag").attr("alt", msg.data.current_condition[0].weatherDesc[0].value);

                var forcasting = "";
                var currentDate;
                if (daysCount > 5) {
                    alert("maximum 5 forcasting days");
                    daysCount = 5;
                    return;
                }
                for (var i = 1; i < daysCount; i++) {
                    currentDate = new Date(msg.data.weather[i].date);
                    forcasting += "<div><h3>" + weekday[currentDate.getDay()] + "</h3><img src='" + msg.data.weather[i].weatherIconUrl[0].value + "' alt='" + msg.data.weather[i].weatherDesc[0].value + "' /> <h4>" + msg.data.weather[i].tempMaxC + " C</h4></span>";
                }
                //.split('-')[2] "<span><h5>Today</h5><img src='" + msg.data.weather[0].weatherIconUrl[0].value + "' alt='" + msg.data.weather[0].weatherDesc[0].value + "' /> <h4>" + msg.data.weather[0].tempMaxC + " </h4></span> <span><h5>Tomorrow</h5><img src='" + msg.data.weather[1].weatherIconUrl[0].value + "' alt='" + msg.data.weather[1].weatherDesc[0].value + "' /> <h4>" + msg.data.weather[1].tempMaxC + " </h4></div>"
                $("#nextday").html(forcasting);
            }
        });
    }
</script>
