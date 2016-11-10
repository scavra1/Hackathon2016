#ifndef VIGENERES_CYPHER_H
#define VIGENERES_CYPHER_H

extern "C"
{
	__declspec(dllexport) unsigned int DecodeC(unsigned char * InputText, int textLength, unsigned char * password, int passwordLength);
	__declspec(dllexport) unsigned int EncodeC(unsigned char * InputText, int textLength, unsigned char * password, int passwordLength);
}
#endif
