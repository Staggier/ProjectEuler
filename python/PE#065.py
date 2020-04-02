# The Problem can be found here: https://projecteuler.net/problem=65

def eConvergents(num):
    i = 2
    j = 1
    k = 2
    
    lst = list((2, 3, 8))
    while len(lst) < num:
        if j >= 3:
            lst.append(((2 * k) * lst[i]) + lst[i - 1])
            j = 1
            k += 1
        else:
            lst.append(lst[i] + lst[i - 1])
            j += 1

        i += 1
        
    return lst[i]

def digitSum(n):
    s = str(n)
    ans = 0

    for i in range(0, len(s)):
        ans += int(s[i])
    return ans

print(digitSum(eConvergents(100)))