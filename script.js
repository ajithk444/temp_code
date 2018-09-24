<script>
    $(function () {

	$('#popupDatepicker').datepick();
	$('#inlineDatepicker').datepick({
	    //dateformat: 'mm/dd/yyyy',
	    onSelect: showDate,
	    multiSelect: 999,
	});
});

var selectedDates = new Array();

function showDate(date) {
    alert('The date chosen is ' + date);
    selectedDates = date;
    alert(selectedDates);
    var dates = $('#inlineDatepicker').datepick('getDate');
    //alert(dates);
}
</script>
