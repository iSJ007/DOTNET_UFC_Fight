// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function() {
  function setupAutocomplete(inputSelector, suggestionBoxSelector, hiddenFieldSelector) {
      $(inputSelector).on("input", function() {
          var term = $(this).val().trim();
          if (term.length >= 2) {
              $.ajax({
                  url: "http://localhost:5127/Fighter/Autocomplete/" + term,
                  dataType: "json",
                  success: function(data) {
                      showSuggestions(data, suggestionBoxSelector, inputSelector, hiddenFieldSelector);
                  },
                  error: function(jqXHR, textStatus, errorThrown) {
                      console.error("Error fetching suggestions:", textStatus, errorThrown);
                      hideSuggestions(suggestionBoxSelector);
                  }
              });
          } else {
              hideSuggestions(suggestionBoxSelector);
          }
      });
  }

  function showSuggestions(data, suggestionBox, inputBox, hiddenField) {
      $(suggestionBox).empty();
      if (data.length > 0) {
          $(suggestionBox).removeClass("hidden");
          $.each(data, function(index, value) {
              var suggestionItem = $('<li class="list-group-item">' + value.fighterName + '</li>');
              suggestionItem.click(function() {
                  $(inputBox).val(value.fighterName);
                  $(hiddenField).val(value.fighterId);
                  hideSuggestions(suggestionBox);
              });
              $(suggestionBox).append(suggestionItem);
          });
      } else {
          hideSuggestions(suggestionBox);
      }
  }

  function hideSuggestions(suggestionBox) {
      $(suggestionBox).addClass("hidden").empty();
  }

  if ($("#fighter1Name").length) {
     console.log($("#fighter1Name"));
  }
  // Setup autocomplete for fighter stats page
  setupAutocomplete("#fighterName", "#autocomplete-suggestions", "#fighterId");

  // Setup autocomplete for fight page
  setupAutocomplete("#fighter1Name", "#autocomplete-suggestions-1", "#fighterId1");
  setupAutocomplete("#fighter2Name", "#autocomplete-suggestions-2", "#fighterId2");

  // Fight page run button click event
  $("#runFight").click(function() {
     
      var fighter1Id = $("#fighterId1").val();
      var fighter2Id = $("#fighterId2").val();

      $.ajax({
          url: "http://localhost:5127/Fighter/Winner/" + fighter1Id + "/" + fighter2Id,
          type: "GET",
          data: {
              fighter1Id: fighter1Id,
              fighter2Id: fighter2Id
          },
          success: function(data) {
              console.log(data);
              var winnerName = data.fighterName;
              $("#winnerText").text("Winner: " + winnerName);
              $("#winnerBox").removeClass("d-none");

          },
          error: function(jqXHR, textStatus, errorThrown) {
              console.error("Error fetching winner:", textStatus, errorThrown);
          }
      });
  });
});

function setStats() {
  const ele = document.getElementById("fighterId");
  const id = ele.value;
  if (!id) {
      console.error("Fighter ID is empty.");
      return;
  }
  console.log(id);
  $.ajax({
      url: "http://localhost:5127/Fighter/Details/" + id,
      dataType: "json",
      success: function(data) {
          console.log(data);
          $("#fighterNam").text(data.fighterName); // Corrected ID to #fighterName
          $("#fighterNick").text(data.fighterNick); 
          let location = data.fighterLoc + " " + data.fighterCountry;
          $("#fighterLocation").text(location); 

           $("#fighterClass").text(data.fighterClass);
         
            $("#fighterHeight").text(data.fighterHeight);
            $("#fighterWeight").text(data.fighterWeight);
            $("#fighterReach").text(data.fighterReach);
            $("#fighterStance").text(data.fighterStance);
            $("#fighterDob").text(data.fighterDob);
            $("#fighterSlpm").text(data.fighterSlpm);
            $("#fighterStracc").text(data.fighterStracc);
            $("#fighterTdavg").text(data.fighterTdavg);
            $("#fighterSubavg").text(data.fighterSubavg);
            $("#fighterTdacc").text(data.fighterTdacc);
            $("#fighterTddef").text(data.fighterTddef);
            $("#fighterStrdef").text(data.fighterStrdef);

          // Call new function to handle suggestions
      },
      error: function(jqXHR, textStatus, errorThrown) {
          console.error("Error fetching fighter details:", textStatus, errorThrown);
          // You can hide elements or display a message to the user here.
      }
  });
}
