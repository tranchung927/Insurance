function sign_up() {
  var inputs = document.querySelectorAll(".input_form_sign");
  document.querySelectorAll(".ul_tabs > li")[0].className = "";
  document.querySelectorAll(".ul_tabs > li")[1].className = "active";

  for (var i = 0; i < inputs.length; i++) {
    if (i == 2) {
    } else {
      document.querySelectorAll(".input_form_sign")[i].className =
        "input_form_sign d_block";
    }
  }

  setTimeout(function () {
    for (var d = 0; d < inputs.length; d++) {
      document.querySelectorAll(".input_form_sign")[d].className =
        "input_form_sign d_block active_inp";
    }
  }, 100);

  document.querySelector(".btn_sign").innerHTML = "SIGN UP";
}

function sign_in() {
  var inputs = document.querySelectorAll(".input_form_sign");
  document.querySelectorAll(".ul_tabs > li")[0].className = "active";
  document.querySelectorAll(".ul_tabs > li")[1].className = "";

  for (var i = 0; i < inputs.length; i++) {
    switch (i) {
      case 1:
        break;
      case 2:
      default:
        document.querySelectorAll(".input_form_sign")[i].className =
          "input_form_sign d_block";
    }
  }

  setTimeout(function () {
    for (var d = 0; d < inputs.length; d++) {
      switch (d) {
        case 1:
          break;
        case 2:

        default:
          document.querySelectorAll(".input_form_sign")[d].className =
            "input_form_sign d_block";
          document.querySelectorAll(".input_form_sign")[2].className =
            "input_form_sign d_block active_inp";
      }
    }
  }, 100);

  setTimeout(function () {
    for (var d = 0; d < inputs.length; d++) {
      switch (d) {
        case 1:
          break;
        case 2:

          break;
        default:
          document.querySelectorAll(".input_form_sign")[d].className =
            "input_form_sign";
      }
    }
  }, 1500);
  document.querySelector(".btn_sign").innerHTML = "SIGN IN";
}



window.onload = function () {
  document.querySelector(".cont_centrar").className =
    "cont_centrar cent_active";
};
