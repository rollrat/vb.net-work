/*************************************************************************
  
   Copyright (C) 2015. rollrat. All Rights Reserved.

------
FILE NAME:
   
   main.c

Project:

   Graph Plot Program

------
   AUTHOR: HyunJun Jeong  2015-01-24

***************************************************************************/

#include <Windows.h>

static HINSTANCE g_hInst;

static LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
static LPCTSTR lpszClass = TEXT("RollRat Graph Plot");


static LRESULT CALLBACK WndProc(HWND hWnd, UINT iMsg, WPARAM wParam, LPARAM IParam)
{
	HDC hdc;
	PAINTSTRUCT ps;

	switch (iMsg)
	{
	case WM_PAINT:
		break;
	case WM_KEYDOWN:
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	}
	return (DefWindowProc(hWnd, iMsg, wParam, IParam));
}

/////////////////////////////////////////////////////////
////
////	¡¯¿‘¡°
////
/////////////////////////////////////////////////////////
int APIENTRY wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpszCmdParam, int nCmdShow)
{
	HWND hWnd;
	MSG Message;
	WNDCLASSEX WndClass = { sizeof(WNDCLASSEX), CS_HREDRAW | CS_VREDRAW, WndProc, 0, 0, hInstance,
		LoadIcon(NULL, IDC_ARROW), LoadCursor(NULL, IDC_ARROW),
		(HBRUSH)(COLOR_BTNFACE + 1),
		NULL, lpszClass };

	if(FindWindow(NULL, lpszClass)) {
		MessageBox(HWND_DESKTOP, TEXT("Program is already running."), lpszClass, MB_OK | MB_ICONERROR);
		return 0;
	}

	g_hInst = hInstance;

	RegisterClassEx((LPWNDCLASSEX)&WndClass);

	hWnd = CreateWindowEx(0, lpszClass, lpszClass, WS_CAPTION | WS_SYSMENU,
		CW_USEDEFAULT, CW_USEDEFAULT, 800, 700,
		NULL, (HMENU)NULL, hInstance, NULL);

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	while (GetMessage(&Message, NULL, 0, 0)) {
		TranslateMessage(&Message);
		DispatchMessage(&Message);
	}

	return (int)Message.wParam;
}