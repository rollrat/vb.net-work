/*************************************************************************
  
   Copyright (C) 2015. rollrat. All Rights Reserved.

------
FILE NAME:
   
   gc.h

Abstract:

   Graph Control

------
   AUTHOR: HyunJun Jeong  2015-01-24

***************************************************************************/

#ifndef _GC_
#define _GC_

#include <Windows.h>

#define	GCSTYLE_CROSS		0x0001
#define GCSTYLE_CROSSDIG	0x0002

#define GCM_INVALIDATE		WM_USER+1
#define GCM_GETCURSORVALUE	WM_USER+2
#define GCM_GETSIZE			WM_USER+3
#define GCM_SETSIZE			WM_USER+4
#define GCM_SETEQUATION		WM_USER+5
#define GCM_SETFUNCTION		WM_USER+6
#define GCM_SETVALIABLE		WM_USER+7

typedef struct _tag_gc_valiable_ {
	int iCount;		// 변수 개수

	//	0: uint
	//	1: int
	//	2: double
	int *iOption;

	char **chpName;
	size_t *szName;
}	GCVALIABLE, *PGCVALIABLE;


void GcRegister();


#endif