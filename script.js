 $.ajax({
            type: "GET",
            url: '@Url.Action("Link", "Task")',
            data: params,
            dataType: "json",
            success: function (response) {
                if(response.success || response.message=='Success' ){
                    updateProjectDurationInfo();
                    ajaxLoader.hide();
                }
                if(response.message =='MilestoneError'){
                    milestoneTryLinkCallback();
                }
                else if(response.message=='RecursiveLinkError'){
                    ajaxLoader.hide();
                    Validator.ShowNotifyMessage("You cannot create recursive links between tasks.", false, 'middle-center', 'warning');
                    arrow.childrenTask.swimLane.view.deleteArrow(arrow);
                    arrow.remove();
                    DashboardButtons.align.click();                
                }
                //if(response==null)
                //{
                //    alert(3);
                //    updateProjectDurationInfo();
                //    ajaxLoader.hide();
                //}
            },
            error: function (response) {
              
            }
        });
    };
