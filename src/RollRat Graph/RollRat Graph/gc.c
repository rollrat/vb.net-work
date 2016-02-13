/*************************************************************************
  
   Copyright (C) 2015. rollrat. All Rights Reserved.

------
FILE NAME:
   
   gc.c

Abstract:

   Graph Control

------
   AUTHOR: HyunJun Jeong  2015-01-24

***************************************************************************/

#include <Windows.h>
#include <malloc.h>
#include "gc.h"

typedef struct _tag_gc_internal_ {
	LONG lStyle;
	COLORREF backColor;
	RECT rtSize;
}	GCINTERNAL, *PGCINTERNAL;

static LPCTSTR lpszClass = TEXT("RollRatGC+");

static LRESULT CALLBACK GcProc(HWND hWnd, UINT iMsg, WPARAM wParam, LPARAM IParam);
static BOOL GciGetWindowStyle(HWND hWnd, LONG lStyle);
static void GciDrawGraph(HWND hWnd, HDC hdc, PGCVALIABLE var, RECT rt);

static LRESULT CALLBACK GcProc(HWND hWnd, UINT iMsg, WPARAM wParam, LPARAM IParam)
{
	HDC hdc;
	PAINTSTRUCT ps;
	PGCINTERNAL option;
	RECT rt;
	static PGCVALIABLE var;
	
	option = (PGCINTERNAL *)GetWindowLong(hWnd, 0);
	switch (iMsg)
	{
	case WM_CREATE:
		option = (GCINTERNAL *)calloc(sizeof(GCINTERNAL), 1);
		SetWindowLong(hWnd, 0, (LONG)option);
		option->backColor = GetSysColor(COLOR_BTNFACE);
		return 0;
	case WM_PAINT:
		GciDrawGraph(hdc, var, rt);
		return 0;
	case WM_KEYDOWN:
		return 0;
	case WM_DESTROY:
		return 0;
	case GCM_SETSIZE:
		GetClientRect(hWnd, &rt);
		option->rtSize = rt;
		return 0;
	case GCM_GETSIZE:
		return &option->rtSize;
	case GCM_SETVALIABLE:
		var = (PGCVALIABLE)wParam;
		return TRUE;
	case WM_SIZE:
		SendMessage(hWnd, GCM_INVALIDATE, 0, 0);
		return 0;
	}
	return (DefWindowProc(hWnd, iMsg, wParam, IParam));
}

static BOOL GciGetWindowStyle(HWND hWnd, LONG lStyle)
{
	return GetWindowLong(hWnd, GWL_STYLE) & lStyle;
}

static void GciDrawGraph(HWND hWnd, PGCVALIABLE var, RECT rt)
{
	if (GciGetWindowStyle(hWnd, GCSTYLE_CROSS)) {

	} else if (GciGetWindowStyle(hWnd, GCSTYLE_CROSSDIG)) {

	}
}

/////////////////////////////////////////////////////////
////
////	¡¯¿‘¡°
////
/////////////////////////////////////////////////////////
void GcRegister()
{
	WNDCLASSEX WndClass = { sizeof(WNDCLASSEX), 0, GcProc, 0, 4, GetModuleHandle(NULL),
		NULL, LoadCursor(NULL, IDC_ARROW),
		(HBRUSH)(COLOR_BTNFACE + 1),
		NULL, lpszClass };

	RegisterClassEx((LPWNDCLASSEX)&WndClass);
}
