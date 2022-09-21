const container = document.getElementById("login");
const modal = new bootstrap.Modal(container);
//this function closes the Login modal when button "Sign Up Now" is clicked
document.getElementById("modalClose").addEventListener("click", function () {
    modal.hide();
});