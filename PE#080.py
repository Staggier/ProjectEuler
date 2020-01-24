# The Problem can be found here: https://projecteuler.net/problem=80

def SqrtDigitSum(n, p):
    quotient = 0
    s = str(n)
    if len(s) % 2 == 0:
        remainder = int(s[0] + s[1])
        l = 2
    else:
        remainder = int(s[0])
        l = 1

    ans = 0
    i = 9

    while i >= 0:
        if i ** 2 <= remainder:
            remainder = remainder - (i ** 2)
            quotient = i
            ans = ans + i
            break
        i = i - 1

    i = 1
    while i <= p - 1:
        remainder = remainder * 100 if l >= len(s) else (remainder * 100) + int(s[l] + s[l + 1])
        j = 9

        while j >= 0:
            temp = (((quotient * 2) * 10) + j) * j
            if temp <= remainder:
                i = i + 1
                quotient = (quotient * 10) + j
                ans = ans + j
                remainder = remainder - temp
                break
            j = j - 1
        l = l + 2
        
    return ans

def SumIrrationalRoots():
    i = 1
    ans = 0
    for i in range (1, 101):
        if (i ** (1 / 2)) % 1 != 0:
            ans += SqrtDigitSum(i, 100)
    return ans
    
print(SumIrrationalRoots())