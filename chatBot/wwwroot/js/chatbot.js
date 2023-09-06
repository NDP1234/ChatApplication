
  
$(document).on('click', '#openUserList', function () {
    console.log("clicked");
    $.ajax({
        url: "/ChatBot/userList",
        success: function (data) {
            $('.UserListContainer').html(data);
        }
    })
})
$(document).on('click', '#openInductionUserList', function () {
    console.log("clicked");
    $.ajax({
        url: "/ChatBot/InductionUser",
        success: function (data) {
            $('.InductionUserListContainer').html(data);
        }
    })
})

$(document).on('click', '.userChat', function () {
    var userId = $(this).val();
    console.log(userId);
    console.log("clicked");
    $('tr').removeClass('highlighted');
    $(this).closest('tr').addClass('highlighted');
    $.ajax({
        url: "/ChatBot/chatView?userId=" + userId,
        success: function (data) {
            $('.UserChatDetails').html(data);
        }
    })
})

$(document).on('click', '.inductionUserChat', function () {
    var userId = $(this).val();
    console.log(userId);
    console.log("clicked");
    $('tr').removeClass('highlighted');
    $(this).closest('tr').addClass('highlighted');
    $.ajax({
        url: "/ChatBot/chatViewForInductionUser?userId=" + userId,
        success: function (data) {
            $('.InductionUserChatDetails').html(data);
        }
    })
})

document.getElementById('openUserList').addEventListener('click', function () {
    Swal.fire({
        title: "click on 'Send the message' button to communicate",
        icon: 'info',
        confirmButtonText: 'OK'
    });
});
document.getElementById('openInductionUserList').addEventListener('click', function () {
    Swal.fire({
        title: "click on 'Send the message' button to communicate",
        icon: 'info',
        confirmButtonText: 'OK'
    });
});


$(document).on('click', '#post-message', function () {
    var toUserId = $(this).attr("data-toUserId");
    console.log(toUserId);
    var message = $('#message-text').val();
    console.log(message);
    $.ajax({
        url: '/ChatBot/SaveComments',
        type: 'POST', 
        data: {
            sendToUser: toUserId,
            messageTxt: message
        },
        success: function (data) {
            if (data === true) {
                $('#message-text').val('');
                Swal.fire({
                    title: "message sent successfully",
                    icon: 'success',
                    confirmButtonText: 'OK'
                });
                $.ajax({
                    url: "/ChatBot/chatView?userId=" + toUserId,
                    success: function (data) {
                        $('.UserChatDetails').html(data);
                    }
                })
            }
        }
    });
});

$(document).on('click', '#post-message-for-inductionUser', function () {
    var toUserId = $(this).attr("data-toInductionUserId");
    console.log(toUserId);
    var message = $('#message-text-for-inductionUser').val();
    console.log(message);
    $.ajax({
        url: '/ChatBot/SaveCommnetsForInductionUser',
        type: 'POST',
        data: {
            sendToUserId: toUserId,
            messageText: message
        },
        success: function (data) {
            if (data === true) {
                $('#message-text-for-inductionUser').val('');
                Swal.fire({
                    title: "message sent successfully",
                    icon: 'success',
                    confirmButtonText: 'OK'
                });
                $.ajax({
                    url: "/ChatBot/chatViewForInductionUser?userId=" + toUserId,
                    success: function (data) {
                        $('.InductionUserChatDetails').html(data);
                    }
                })
            }
        }
    });
});