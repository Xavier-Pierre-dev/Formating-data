import json
import os
import re

def function_formating1(lresult):
    #print("function for formating")
    return lresult

def function_unformating1(lresult):
    #print("function for unformating")
    return lresult



def formating(data, path, reverse):
    'initialise the outpur result'
    result = data
    
    'read json configuration file'
    script_dir = os.path.dirname(__file__)
    rel_path = path
    abs_file_path = os.path.join(script_dir, rel_path)
    f = open(abs_file_path, "r")
    #f = open(path,"r")
    Configuration = json.load(f)
    f.close()


    i = 0
    input = "input"
    output = "output"
    increment = 1
    size = len(Configuration) 

    if(reverse==True):
        i = len(Configuration) - 1
        size = 0 - 1
        input = "output"
        output = "input"
        increment = -1
         

    for element in range(i, size, increment):
        #print(Configuration[element][0])

        # other way for use something else than try / except statement
        # if "replacement" in Configuration[element][0].keys():
        #    print("yes")

        try:
            if(Configuration[element][0]["replacement"]):
                result = result.replace(Configuration[element][0]["replacement"][input], Configuration[element][0]["replacement"][output])
        except:
            pass

        try:
            if(Configuration[element][0]["regex"]):
                if(reverse==True):
                    result = re.sub(r'{}'.format(Configuration[element][0]["regex"]["regex-unformating-input"]), r'{}'.format(Configuration[element][0]["regex"]["regex-unformating-output"]), result)
                else:
                    result = re.sub(r'{}'.format(Configuration[element][0]["regex"]["regex-formating-input"]), r'{}'.format(Configuration[element][0]["regex"]["regex-formating-output"]), result)
        except:
            pass

        try:
            if(Configuration[element][0]["function"]):
                c = ''
                if(reverse==True):
                    c= Configuration[element][0]["function"]["function_unformating"]
                else:
                    c= Configuration[element][0]["function"]["function_formating"]

                
                #choice for function
                if (c=="function_formating1"):
                    #print("function for formating")
                    result = function_formating1(result)
                elif (c=="function_unformating1"):
                    #print("function for unformating")
                    result = function_unformating1(result)
                else:
                    print("no function implemented with this name")

        except:
            pass


    return result

test = "AKLOP89J"
print("test = ",test)
test = formating(test, "configuration.json", False)
print("formated test = ",test)
test = formating(test, "configuration.json", True)
print("unformated (test formated) = test = ", test)

