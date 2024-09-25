// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* setup navigation effects */
const addNavigationEffects = () => {
  var links = document.querySelectorAll('.nav-link');
  var currentPath = window.location.pathname;

  links.forEach(function (link) {
    var linkPath = link.getAttribute('href');
    if (currentPath === linkPath || (currentPath === '/' && linkPath === '/Index')) {
      link.classList.add('active');
    }
  });
}

document.addEventListener("DOMContentLoaded", function () {
  addNavigationEffects();
});