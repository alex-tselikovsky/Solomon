$( document ).ready(function() {

    var range = false;

    function insertAtCursor(myField, myValue) {
        //IE support
        if (document.selection) {
            myField.focus();
            sel = document.selection.createRange();
            sel.text = myValue;
        }
        //MOZILLA and others
        else if (myField.selectionStart || myField.selectionStart == '0') {
            var startPos = myField.selectionStart;
            var endPos = myField.selectionEnd;
            myField.value = myField.value.substring(0, startPos)
                + myValue
                + myField.value.substring(endPos, myField.value.length);
        } else {
            myField.value += myValue;
        }
    }

    $(".autocomplete-data a").click(function(e){
        e.preventDefault();
        $(".user-commnet").focus();
        let values = $(".user-commnet").val();
        
        values = values.substring(0, $(".user-commnet")[0].selectionStart ) + this.innerHTML + values.substring($(".user-commnet")[0].selectionEnd, values.length);
        
        $(".user-commnet").val(values);
    })
    $("#ans #shab p").click(function(){
        let textdata = this.innerHTML;

        
        $(".autocomplete-data a").each(function(index, el){
            
            let re = new RegExp(`\\[${$(el).data().tag}\\]`,"g");
            textdata = textdata.replace(re, el.innerHTML);
        })
        $(".user-commnet").val(textdata.trim());
    })
});