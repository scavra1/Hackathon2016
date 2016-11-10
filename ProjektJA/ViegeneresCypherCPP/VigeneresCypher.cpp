#include "VigeneresCypher.h"

/////////////////////////////////////////////////////////////////////
//
//
//
//	Function applies a Vigeneres encoding to char string /a InputText using /a password 
//	as an encoding string. If password is shorter than /a InputText string, function repeats password 
//	to encode entire InputText string.
//	Example >> For arguments:
//	InputText: radioactive, password: bomb
//	Encoding operation looks like:
//	InputText: radioactive
//	Password:  bombbombbom
//  ------------------------
//  Result:    sopjpooujjq
// 
//	*************  Parameters:  ***********************
//	/param InputText - pointer reference to text to be encoded
//	/param textLength - length of text to be encoded
//	/param password - password that the InputText is encoded with
//	/param passwordLength - length of password
//  
//
//	*************  Function Returns:  ******************
//	> unsigned int value that represents error code. Error codes:
//		0 - encoding was successful
//		1 - password contains incorrect letter/symbol
//		2 - input text contains incorrect letter/symbol
//	> modified char string as /param InputText is an In->Out parameter(given by reference)
// 
//
//
//
///////////////////////////////////////////////////////////////////////

unsigned int EncodeC(unsigned char * InputText, int textLength, unsigned char * password, int passwordLength)
{
	//loop through every char in password string in order to check if it is correct
	int i = 0;
	while (i < passwordLength)
	{
		if (!(password[i] >= 'a' && password[i] <= 'z'))
			return password[i];	// return error code #1 if it is not correct

		++i;
	}

	int passwordCounter = 0;
	// loop through every char in string
	for (int i = 0; i < textLength; ++i)
	{
		unsigned char passwordLetter = password[passwordCounter];
		unsigned char textLetter = InputText[i];

		// if input text char IS NOT a letter
		if (!(textLetter >= 'a' && textLetter <= 'z'))
		{
			// if it is space - ignore encoding section
			if (textLetter == ' ')
				continue;
			else
				return 2; // return error code #2
		}
		// ACTUAL ALGORITHM BEGINS HERE

		// count the difference between password's letter and letter 'a'(97)
		unsigned char diff = passwordLetter - 'a';
		// create encoded letter by computed difference to input text letter
		unsigned char encodedLetter = textLetter + diff;

		// if encoded letter is greater than 'z' letter code (122)
		if (encodedLetter > 'z')
		{
			encodedLetter -= 26;
		}

		InputText[i] = encodedLetter; //modify input string with computed code letter

									  // reset password counter if it hits last password's char
		if (++passwordCounter >= passwordLength)
			passwordCounter = 0;
	}
	return 0; // if all encoding went good :)
}



/////////////////////////////////////////////////////////////////////
//
//
//
//	Function applies a Vigeneres decoding operation to char string /a InputText using /a password 
//	as an decoding string. If password is shorter than /a InputText string, function repeats password 
//	to decode entire InputText string.
//	Example >> For arguments:
//	InputText: sopjpooujjq, password: bomb
//	Decoding operation looks like:
//	InputText: sopjpooujjq
//	Password:  bombbombbom
//  -----------------------
//  Result:    radioactive
//
//	*************  Parameters:  ***********************
//	/param InputText - pointer reference to text to be decoded
//	/param textLength - length of text to be decoded
//	/param password - password that the InputText is decoded with
//	/param passwordLength - length of password
//  
//
//	*************  Function Returns:  ******************
//	> unsigned int value that represents error code. Error codes:
//		0 - decoding was successful
//		1 - password contains incorrect letter/symbol
//		2 - input text contains incorrect letter/symbol
//	> modified char string as /param InputText is an In->Out parameter(given by reference)
// 
//
//
//
///////////////////////////////////////////////////////////////////////

unsigned int DecodeC(unsigned char * InputText, int textLength, unsigned char * password, int passwordLength)
{
	// loop through every char in password string in order to check if it is correct
	int i = 0;
	while (i < passwordLength)
	{
		if (!(password[i] >= 'a' && password[i] <= 'z'))
			return 1; // return error code #1
		++i;
	}

	// loop through every char in input text and decode letter
	int passwordCounter = 0;
	for (int i = 0; i < textLength; i++)
	{
		unsigned char passwordLetter = password[passwordCounter];
		unsigned char textLetter = InputText[i];

		// if input text char is not a letter
		if (!(textLetter >= 'a' && textLetter <= 'z'))
		{
			// if it is space - ignore decoding section
			if (textLetter == ' ')
				continue;
			else
				return 2; // return error code #2
		}

		// ACTUAL DECODING ALGORITHM BEGINS HERE

		// count difference between password letter and letter 'a' (alphabetical displacement)
		unsigned char diff = passwordLetter - 'a';

		// encode letter (subtraction)
		unsigned char encodedLetter = textLetter - diff;

		// check if decoded value is lesser than 'a'
		if (encodedLetter < 'a')
		{
			encodedLetter += 26;
		}
		// decode letter
		InputText[i] = encodedLetter;

		if (++passwordCounter >= passwordLength)
			passwordCounter = 0;
	}
	return 0;	// if decoding went good :)
}
