
$(document).ready(() => {
   // $(".input-nascimento").inputmask("mask", { mask: "99/99/9999"});
    //$(".input-nascimento").inputmask("datetime", {
    //    mask: "1-2-y h:s",
    //    placeholder: "dd-mm-yyyy hh:mm",
    //    leapday: "-02-29",
    //    separator: "-",
    //    alias: "dd/mm/yyyy"
    //});
    
    $("#Cpf").inputmask("mask", { mask: "999.999.999-99" });
    $("#Telefone").inputmask("mask", {
        mask: ["(99) 9999-9999", "(99) 99999-9999",],
        keepStatic: true 
    });
    

});

