# 🚀 Data Formating : javascript 🚀

1. We use ```g``` flags for ```regex input```, that mean we will match and replace every similar pattern not only the first one. 
2. Switch case inside the code for switch beetween function by default the code will print ```no function implemented with this name``` if the name inside the configuration file wasn't inside switch case statement.
3. Path is relatif to the folder and fully define inside the call of the function
4. reverse=true we perform a unformating, and if reverse=false we perform a formating on the data


```javascript
test = "AKLOP89J"
console.log("test = ",test)
test = formating(test, "./configuration.json", false)
console.log("formated test = ",test)
test = formating(test, "./configuration.json", true)
console.log("unformated (test formated) = test = ", test)
```

return 
```
test =  AKLOP89J
function for formating
formated test =  JZKLOP89
function for unformating
unformated (test formated) = test =  AKLOP89J
```

note : inside the code i let's ````console.log(function for formating)```` and ````console.log(function for unformating)```` just for test purpose and show fact the code call the function correctly.

<br>

So we see that we perform formating and unformating data with the same function and configuration file. Note that if we use multiple simple replacement that can break because if we have ``"ABCD"`` and want to format that the result will be ```DDDD``` if we perform this changement (```A-->B-->C-->D```), then the reverse will be ```AAAA``` because of that it's better to use regex and function, or only 1 simple replacement. If you want to use multiple replacement you need to make sur that your replacement will not be concurentiel beetween each other so you can't do : 
* ```A-->B-->C-->D```
* but you can ```CAGTG-->Dmodlk``` and ```Bdez-->Cdes``` and ```AAZS-->Bvgr``` because each input/output wasn't contains in an other input output