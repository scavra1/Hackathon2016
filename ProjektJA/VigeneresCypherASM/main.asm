;------------------------------------------------------------------------- 
.386 
.MODEL FLAT, STDCALL 
OPTION CASEMAP:NONE 
.NOLIST 
.NOCREF 
INCLUDE C:\masm32\include\windows.inc 
.LIST 

.code 

DllEntry PROC hInstDLL:HINSTANCE, reason:DWORD, reserved1:DWORD 
mov eax, TRUE 
ret 
DllEntry ENDP 
;**************************************************************************** 
;* Procedura FindChar_1
;* * 
;* Bezposrednia adresacja indeksowa * 
;* Parametry wejsciowe: * 
;* AH - szukany znak 'J' * 
;* Parametry wyjsciowe: * 
;* EAX - BOOL TRUE Found, FALSE not found * 
;* * 


AsmEncode PROC, inputText:PTR BYTE, inputLength:DWORD, password:PTR BYTE, passwordLength:DWORD

	; eax = esi
	; ecx = edi

	mov			edi, inputText
	mov			esi, password

	xor			eax, eax
	xor			ecx, ecx
	
	CheckPasswordLoop:
	mov			al, byte ptr[esi]		; move password byte to al
	cmp			al, 61h					; compare al to 'a' value
	jl			PassCharNotaLetter		; jump if al is lesser than 'a' value

	cmp			al, 7Ah					; compare byte to 'z' value
	jg			PassCharNotaLetter		; jump if byte is greater than 'z' value

	inc			esi
	inc			ecx						; increment passwordLoop repeats
	cmp			ecx, passwordLength		; if passwordLength is equal to loop repeats counter
	jne			CheckPasswordLoop		; go to begining of loop

	
	mov			esi, inputText			; sets esi pointer onto first char of input text
	mov			edi, password			; sets edi pointer onto first char of password
	xor			ecx, ecx				; zeros inputText offset counter
	xor			edx, edx				; zeros password offset counter

	EncodeTextLoop:
	
	; Checking if text byte is 'space' sign or is lesser than 'a' value or greater than 'z' value
	; if is equal 'space' - dont modify the string and increment text pointer only
	; if is lesser than 'a' or greater than 'z' - go to return error label

	mov			al, byte ptr[esi]		; move input text byte to al
	cmp			al, 20h					; check if byte is not a 'space' sign
	je			IncrementTextPointer	; if it is - go to incrementing text pointer label
	
	cmp			al, 61h					; compare al to 'a' value
	jl			TextCharNotaLetter		; jump to return statement

	cmp			al, 7Ah					; compare byte to 'z' value
	jg			TextCharNotaLetter		; jump to return statement


	; encoding operation begins here
	; 1. subtract 'a' value from text letter
	; 2. add to result a value of password letter
	; 3. check if result is greater than 'z' value
	; 4.1 if it is - make the result byte fit in alphabet (see GreaterThanZ label)
	; 4.2 if it is not - change the letter in the input string

	sub			al, 61h					; subtract 'a' value from letter
	add			al, byte ptr[edi]		; add to al a value of password letter

	cmp			ax, 7Ah					; check if encoded letter is greater than 'z' value
	jg			EncodedGreaterThanZ

	ChangeLetter:
	mov			byte ptr[esi], al		; encode the input text letter

	inc			edi						; set edi pointer onto next char in password
	inc			edx						; increment password offset counter
	
	IncrementTextPointer:
	inc			esi						; set esi pointer onto next char in input text
	inc			ecx						; increment input text offset counter
	
	cmp			edx, passwordLength		; if password offset hits its end - go back to begin
	je			ResetPasswordCounter
	
	CheckTextCounter:
	cmp			ecx, inputLength		; if input text offset does not hit its end - loop back
	jne			EncodeTextLoop


	mov			eax, 0h					; finish the function with #0 code error
	
	pop			edi
	pop			esi
	ret

	ResetPasswordCounter:
	xor			edx, edx
	jmp			CheckTextCounter

	EncodedGreaterThanZ:
	sub			al, 1Ah					; 'rewind' the alphabet - [0x1A(26) is a number of alphabet letters]
	jmp			ChangeLetter

	PassCharNotaLetter:
	mov			eax, 1h					; finish the function with #1 code error
	
	pop			edi
	pop			esi
	ret

	TextCharNotaLetter:
	mov			eax, 2h					; finish the function with #2 code error
	
	pop			edi
	pop			esi
	ret	

AsmEncode ENDP



AsmDecode PROC, inputText:PTR BYTE, inputLength:DWORD, password:PTR BYTE, passwordLength:DWORD

	; eax = esi
	; ecx = edi

	mov			edi, inputText
	mov			esi, password

	xor			eax, eax
	xor			ecx, ecx
	
	CheckPasswordLoop:
	mov			al, byte ptr[esi]		; move password byte to al
	cmp			al, 61h					; compare al to 'a' value
	jl			PassCharNotaLetter		; jump if al is lesser than 'a' value

	cmp			al, 7Ah					; compare byte to 'z' value
	jg			PassCharNotaLetter		; jump if byte is greater than 'z' value

	inc			esi
	inc			ecx						; increment passwordLoop repeats
	cmp			ecx, passwordLength		; if passwordLength is equal to loop repeats counter
	jne			CheckPasswordLoop		; go to begining of loop

	
	mov			esi, inputText			; sets esi pointer onto first char of input text
	mov			edi, password			; sets edi pointer onto first char of password
	xor			ecx, ecx				; zeros inputText offset counter
	xor			edx, edx				; zeros password offset counter

	EncodeTextLoop:
	
	; Checking if text byte is 'space' sign or is lesser than 'a' value or greater than 'z' value
	; if is equal 'space' - dont modify the string and increment text pointer only
	; if is lesser than 'a' or greater than 'z' - go to return error label

	mov			al, byte ptr[esi]		; move input text byte to al
	cmp			al, 20h					; check if byte is not a 'space' sign
	je			IncrementTextPointer	; if it is - go to incrementing text pointer label
	
	cmp			al, 61h					; compare al to 'a' value
	jl			TextCharNotaLetter		; jump to return statement

	cmp			al, 7Ah					; compare byte to 'z' value
	jg			TextCharNotaLetter		; jump to return statement


	; encoding operation begins here
	; 1. subtract 'a' value from text letter
	; 2. add to result a value of password letter
	; 3. check if result is greater than 'z' value
	; 4.1 if it is - make the result byte fit in alphabet (see GreaterThanZ label)
	; 4.2 if it is not - change the letter in the input string

	add			al, 61h					; subtract 'a' value from letter
	sub			al, byte ptr[edi]		; add to al a value of password letter

	cmp			ax, 61h					; check if encoded letter is lesser than 'a' value
	jl			EncodedLesserThanA

	ChangeLetter:
	mov			byte ptr[esi], al		; encode the input text letter

	inc			edi						; set edi pointer onto next char in password
	inc			edx						; increment password offset counter
	
	IncrementTextPointer:
	inc			esi						; set esi pointer onto next char in input text
	inc			ecx						; increment input text offset counter
	
	cmp			edx, passwordLength		; if password offset hits its end - go back to begin
	je			ResetPasswordCounter
	
	CheckTextCounter:
	cmp			ecx, inputLength		; if input text offset does not hit its end - loop back
	jne			EncodeTextLoop


	mov			eax, 0h					; finish the function with #0 code error
	
	pop			edi
	pop			esi
	ret

	ResetPasswordCounter:
	xor			edx, edx
	jmp			CheckTextCounter

	EncodedLesserThanA:
	add			al, 1Ah					; 'rewind' the alphabet [0x1A(26) is a number of alphabet letters]
	jmp			ChangeLetter

	PassCharNotaLetter:
	mov			eax, 1h					; finish the function with #1 code error
	
	pop			edi
	pop			esi
	ret

	TextCharNotaLetter:
	mov			eax, 2h					; finish the function with #2 code error
	
	pop			edi
	pop			esi
	ret	

AsmDecode ENDP
END DllEntry