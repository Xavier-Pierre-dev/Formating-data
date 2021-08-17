
function function_formating1(lresult){
    console.log("function for formating")
    return lresult
}


function function_unformating1(lresult){
    console.log("function for unformating")
    return lresult
}




function formating(data, path, reverse){
    //initialise result 
    let result = data;
    
    //parse json object
    let configuration = require(path);

    let i = 0;
    let input = "input";
    let output = "output";
    let increment = 1;
    size = configuration.length;

    if(reverse===true){
        i = configuration.length - 1;
        size = 0 - 1;
        input = "output";
        output = "input";
        increment = -1;
    }


    
    for(i ; i!==size  ; i=i+increment){
        //console.log("i = ", i.toString());
        if(configuration[i][0]["replacement"]){
            result = result.replace(""+configuration[i][0]["replacement"][input], ""+configuration[i][0]["replacement"][output]);
        }

        if(configuration[i][0]["regex"]){
            if(reverse===true){
                let patternInput = new RegExp(configuration[i][0]["regex"]["regex-unformating-input"], "g");
                let patternOutput =  ""+configuration[i][0]["regex"]["regex-unformating-output"];
                result = result.replace(patternInput,patternOutput);
            }
            else{
                let patternInput = new RegExp(configuration[i][0]["regex"]["regex-formating-input"], "g");
                let patternOutput =  ""+configuration[i][0]["regex"]["regex-formating-output"];
                result = result.replace(patternInput,patternOutput);
            }
        }

        if(configuration[i][0]["function"]){
            let c = "";
            if(reverse===true){
                c= configuration[i][0]["function"]["function_unformating"]
            }
            else{
                c= configuration[i][0]["function"]["function_formating"]
            }
    
            switch(c){
                case "function_formating1":
                    //console.log("function for formating");
                    result = function_formating1(result);
                    break;
                case "function_unformating1":
                    //console.log("function for unformating");
                    result = function_unformating1(result);
                    break;
                default:
                    console.log("no function implemented with this name")
            }
        }


    }




    return result;
}

test = "AKLOP89J"
console.log("test = ",test)
test = formating(test, "./configuration.json", false)
console.log("formated test = ",test)
test = formating(test, "./configuration.json", true)
console.log("unformated (test formated) = test = ", test)