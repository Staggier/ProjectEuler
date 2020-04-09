#The Problem can be found here: https://projecteuler.net/problem=17

d = {
    1: "one",
    2: "two",
    3: "three",
    4: "four",
    5: "five",
    6: "six",
    7: "seven",
    8: "eight",
    9: "nine",
    10: "ten",
    11: "eleven",
    12: "twelve",
    13: "thirteen",
    14: "fourteen",
    15: "fifteen",
    16: "sixteen",
    17: "seventeen",
    18: "eighteen",
    19: "nineteen",
    20: "twenty",
    30: "thirty",
    40: "forty",
    50: "fifty",
    60: "sixty",
    70: "seventy",
    80: "eighty",
    90: "ninety",
    }

def PE017():
    ans = ""
    for i in range(1, 1001):
        s = str(i)
        length = len(s)
        if length == 1:
            ans += d.get(i)
        elif length == 2:
            if i % 10 == 0 or i <= 20:
                ans += d.get(i)
            else:
                ans += d.get(int(s[0]) * 10) + d.get(int(s[1]))
        elif length == 3:
            if i % 100 == 0:
                ans += d.get(int(s[0])) + "hundred"
            else:
                ans += d.get(int(s[0])) + "hundred"
                if s[1] != "0":
                    if i % 100 <= 20 or (i % 100) % 10 == 0:
                        ans += "and" + d.get(i % 100)
                    else:
                        ans += "and" + d.get(int(s[1]) * 10) + d.get(int(s[2]))
                else:
                    ans += "and" + d.get(int(s[2]))
        else:
            ans += "one" + "thousand"

    return len(ans)

print(PE017())