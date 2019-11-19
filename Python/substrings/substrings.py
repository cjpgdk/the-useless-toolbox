# a small function i wrote to help in an assignment in CS50
n = 2
text = "Hello";  # 'He', 'el', 'll', 'lo'

def substrn(s, n):
    """Return substrings of length n in s"""
    slist = list();
    i = 0;
    l = len(s)
    while l >= i:
        slist.append(s[i:n+i]);
        i += 1
        if i+n > l:
            break
    return slist


print(substrn(text, n))