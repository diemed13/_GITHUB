function Delete(id) {
    var url = document.URL;
    url = url + '/Delete/' + id;
    window.location.replace(url);
}