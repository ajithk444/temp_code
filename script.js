  $('#StartDate, #ActualStartDate, #ActualEndDate').datetimepicker({
            onSelectDate: function () {},

        });





 $.validator.addMethod("validDate", function (value, element) {
            if (value == '' || value == null) {
                return true;
            }
            var arr = value.split(' ');
            if (!/^\d{4}-\d{1,2}-\d{1,2}$/.test(arr[0]))
                return false;
            var isValidTime=false;
            // Parse the date parts to integers
            var parts = arr[0].split("-");
            var day = parseInt(parts[2], 10);
            var month = parseInt(parts[1], 10);
            var year = parseInt(parts[0], 10);
            var timeparts = arr[1].split(":");
            if(arr[1]=='00:00:00')
            {
                isValidTime=true;                
            }
            else
            {
                var hour = parseInt(timeparts[0], 10);
                var minute = parseInt(timeparts[1], 10);
                var second = 0;              
                if(hour >=0 && hour <=23 && minute >=0 && minute<=59 && second >=0 && second<=59)
                    isValidTime=true;
                else if(hour ==24 && minute ==0 && second==0)
                    isValidTime=true;
            }
                if(!isValidTime)
                    return false;
          
            // Check the ranges of month and year
            if (year < 1000 || year > 3000 || month == 0 || month > 12)
                return false;

            var monthLength = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

            // Adjust for leap years
            if (year % 400 == 0 || (year % 100 != 0 && year % 4 == 0))
                monthLength[1] = 29;

            // Check the range of the day
            return day > 0 && day <= monthLength[month - 1];

            if (isValid)
                return false;
            return true;
        });

<link href="~/Content/css/jquery.datetimepicker.min.css" rel="stylesheet" />
<script src="~/Scripts/jquery.datetimepicker.full.js"></script>


