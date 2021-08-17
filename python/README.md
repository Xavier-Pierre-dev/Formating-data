# 🚀 Data Formating : python 🚀

1. The javascript regex ``"$1"`` equivalent in python is ``"\1"`` but like we import a string from a json we need to use ``"\\1"`` because we need to escape the special character for that work.
2. Switch case doesn't exist in python so we use if / elif / else statement instead of switch case inside the code by default the code will print ```no function implemented with this name``` if the name inside the configuration file wasn't inside the if / elif / else statement.
3. Path is relatif to the folder for this example but that can be easily changed by commenting line 18 to 21 and uncommenting line 22
1. reverse=true we perform a unformating, and if reverse=false we perform a formating on the data



```python
test = "AKLOP89J"
print("test = ",test)
test = formating(test, "configuration.json", False)
print("formated test = ",test)
test = formating(test, "configuration.json", True)
print("unformated (test formated) = test = ", test)
```

return 
```
test =  AKLOP89J
formated test =  JDKLOP89
unformated (test formated) = test =  AKLOP89J
```

So we see that we perform formating and unformating data with the same function and configuration file. Note that if we use multiple simple replacement that can break because if we have ``"ABCD"`` and want to format that the result will be ```DDDD``` if we perform this changement (```A-->B-->C-->D```), then the reverse will be ```AAAA``` because of that it's better to use regex and function, or only 1 simple replacement. If you want to use multiple replacement you need to make sur that your replacement will not be concurentiel beetween each other so you can't do : 
* ```A-->B-->C-->D```
* but you can ```CAGTG-->Dmodlk``` and ```Bdez-->Cdes``` and ```AAZS-->Bvgr``` because each input/output wasn't contains in an other input output