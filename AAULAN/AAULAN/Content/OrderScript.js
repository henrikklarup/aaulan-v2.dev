    var javascript_countdown = function () {
        var timeLeft = 10; //number of seconds for countdown
        var keepCounting = 1;
        var noTimeLeftMessage = 'No time left for JavaScript countdown!';
        function countdown() {
            if (timeLeft < 2) {
                keepCounting = 0;
            }
            timeLeft = timeLeft - 1;
        }
        function addLeadingZero(n) {
            if (n.toString().length < 2) {
                return '0' + n;
            } else {
                return n;
            }
        }
        function formatOutput() {
            var hours, minutes, seconds;
            seconds = timeLeft % 60;
            minutes = Math.floor(timeLeft / 60) % 60;
            hours = Math.floor(timeLeft / 3600);
            seconds = addLeadingZero(seconds);
            minutes = addLeadingZero(minutes);
            hours = addLeadingZero(hours);
            return 'Bestil Pizza inden: ' + hours + ':' + minutes + ':' + seconds;
        }
        function showTimeLeft() {
            document.getElementById('javascript_countdown_time').innerHTML = formatOutput(); //time_left;
        }
        function noTimeLeft() {
            document.getElementById('javascript_countdown_time').innerHTML = noTimeLeftMessage;
        }
        return {
            count: function () {
                countdown();
                showTimeLeft();
            },
            timer: function () {
                javascript_countdown.count();
                if (keepCounting) {
                    setTimeout("javascript_countdown.timer();", 1000);
                } else {
                    noTimeLeft();
                }
            },
            init: function (n) {
                timeLeft = n;
                javascript_countdown.timer();
            }
        };
    } ();