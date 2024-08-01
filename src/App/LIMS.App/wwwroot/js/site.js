const Toast = Swal.mixin({
    toast: true,
    position: "top-end",
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,

    //showClass: {
    //    popup: `
    //fadeInRight
    //`
    //},
    //hideClass: {
    //    popup: `
    // fadeOutRight
    //`
    //},
    showClass: {
        popup: `
      animate__animated
      animate__fadeInRight
      animate__faster
    `
    },
    hideClass: {
        popup: `
      animate__animated
      animate__fadeOutRight
      animate__faster
    `
    },
    didOpen: (toast) => {
        toast.onmouseenter = Swal.stopTimer;
        toast.onmouseleave = Swal.resumeTimer;
    }
});


//function CleanInput(editor) {
//    alert("clear")
//    let inputs = document.querySelectorAll('input');
//    let areas = document.querySelectorAll('textarea');
//    areas.forEach(area => area.value = '')
//    inputs.forEach(input => input.value = '');
//    //if (false) {
//    //        document.getElementById('description_ifr').contentDocument?.body?.innerHTML = ""

//    //}
//    if (typeof (tinyMCE) != 'undefined' && editor) {
//        document.getElementById('description_ifr').contentDocument.body.innerHTML = ""
//    }

//}

tinymce.init({
    selector: 'textarea.editor',  // change this value according to your HTML
    max_height: 1000,
    toolbar_sticky: false,
    min_height: 300,
    plugins: [
        "advlist", "anchor", "autolink", "charmap", "code", "fullscreen",
        "help", "image", "insertdatetime", "link", "lists", "media",
        "preview", "searchreplace", "table", "visualblocks", "accordion"
    ],
    toolbar: "undo redo |link image accordion | styles | bold italic underline strikethrough | align | bullist numlist",
    media_alt_source: false,
    placeholder: "Add a Description...",
    hidden_input: true,

});



